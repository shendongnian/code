    void Main()
    {
    	var dataTable = BuildSourceData();
    
    	using (var connection = new OracleConnection("DATA SOURCE=hq_pdb_tcp;PASSWORD=oracle;USER ID=HUSQVIK"))
    	{
    		connection.Open();
    
    		using (var command = connection.CreateCommand())
    		{
    			command.CommandText = "BEGIN HUSQVIK.SP_TEST(:P_TABLE_IN, :P_RESULT_OUT); END;";
    			command.BindByName = true;
    
    			var p1 = command.CreateParameter();
    			p1.ParameterName = "P_TABLE_IN";
    			p1.OracleDbType = OracleDbType.Array;
    			p1.UdtTypeName = "HUSQVIK.CUSTOM_TYPE_ARRAY";
    			p1.Value = ConvertDataTableToUdt<CustomTypeArray, CustomType>(dataTable);
    			command.Parameters.Add(p1);
    
    			var p2 = command.CreateParameter();
    			p2.Direction = ParameterDirection.Output;
    			p2.ParameterName = "P_RESULT_OUT";
    			p2.OracleDbType = OracleDbType.RefCursor;
    			command.Parameters.Add(p2);
    	
    			command.ExecuteNonQuery();
    
    			using (var reader = ((OracleRefCursor)p2.Value).GetDataReader())
    			{
    				var row = 1;
    				while (reader.Read())
    				{
    					Console.WriteLine($"Row {row++}: Attribute1 = {reader[0]}, Attribute1 = {reader[1]}");
    				}
    			}
    		}
    	}
    }
    
    private DataTable BuildSourceData()
    {
    	var dataTable = new DataTable("CustomTypeArray");
    	dataTable.Columns.Add(new DataColumn("Attribute1", typeof(string)));
    	dataTable.Columns.Add(new DataColumn("Attribute2", typeof(string)));
    	
    	dataTable.Rows.Add("r1 c1", "r1 c2");
    	dataTable.Rows.Add("r2 c1", "r2 c2");
    	
    	return dataTable;
    }
    
    public static object ConvertDataTableToUdt<TUdtTable, TUdtItem>(DataTable dataTable) where TUdtTable : CustomCollectionTypeBase<TUdtTable, TUdtItem>, new() where TUdtItem : CustomTypeBase<TUdtItem>, new()
    {
    	var tableUdt = Activator.CreateInstance<TUdtTable>();
    	tableUdt.Values = (TUdtItem[])tableUdt.CreateArray(dataTable.Rows.Count);
    	var fields = typeof(TUdtItem).GetFields();
    	
    	for (var i = 0; i < dataTable.Rows.Count; i++)
    	{
    		var itemUdt = Activator.CreateInstance<TUdtItem>();
    		for (var j = 0; j < fields.Length; j++)
    		{
    			fields[j].SetValue(itemUdt, dataTable.Rows[i][j]);
    		}
    		
    		tableUdt.Values[i] = itemUdt;
    	}
    	
    	return tableUdt;
    }
    
    [OracleCustomTypeMapping("HUSQVIK.CUSTOM_TYPE_ARRAY")]
    public class CustomTypeArray : CustomCollectionTypeBase<CustomTypeArray, CustomType>
    {
    }
    
    [OracleCustomTypeMapping("HUSQVIK.CUSTOM_TYPE")]
    public class CustomType : CustomTypeBase<CustomType>
    {
    	[OracleObjectMapping("ATTRIBUTE1")]
    	public string Attribute1;
    	[OracleObjectMapping("ATTRIBUTE2")]
    	public string Attribute2;
    
    	public override void FromCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		OracleUdt.SetValue(connection, pointerUdt, "ATTRIBUTE1", Attribute1);
    		OracleUdt.SetValue(connection, pointerUdt, "ATTRIBUTE2", Attribute2);
    	}
    
    	public override void ToCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		Attribute1 = (string)OracleUdt.GetValue(connection, pointerUdt, "ATTRIBUTE1");
    		Attribute2 = (string)OracleUdt.GetValue(connection, pointerUdt, "ATTRIBUTE2");
    	}
    }
    
    public abstract class CustomCollectionTypeBase<TType, TValue> : CustomTypeBase<TType>, IOracleArrayTypeFactory where TType : CustomTypeBase<TType>, new()
    {
    	[OracleArrayMapping()]
    	public TValue[] Values;
    
    	public override void FromCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		OracleUdt.SetValue(connection, pointerUdt, 0, Values);
    	}
    
    	public override void ToCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		Values = (TValue[])OracleUdt.GetValue(connection, pointerUdt, 0);
    	}
    
    	public Array CreateArray(int numElems)
    	{
    		return new TValue[numElems];
    	}
    
    	public Array CreateStatusArray(int numElems)
    	{
    		return null;
    	}
    }
    
    public abstract class CustomTypeBase<T> : IOracleCustomType, IOracleCustomTypeFactory, INullable where T : CustomTypeBase<T>, new()
    {
    	private bool _isNull;
    
    	public IOracleCustomType CreateObject()
    	{
    		return new T();
    	}
    
    	public abstract void FromCustomObject(OracleConnection connection, IntPtr pointerUdt);
    
    	public abstract void ToCustomObject(OracleConnection connection, IntPtr pointerUdt);
    
    	public bool IsNull
    	{
    		get { return this._isNull; }
    	}
    
    	public static T Null
    	{
    		get { return new T { _isNull = true }; }
    	}
    }
