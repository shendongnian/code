    void Main()
    {
    	using (var connection = new OracleConnection("DATA SOURCE=hq_pdb_tcp;PASSWORD=oracle;USER ID=HUSQVIK"))
    	{
    		connection.Open();
    
    		using (var command = connection.CreateCommand())
    		{
    			command.CommandText = "DECLARE x SYS.ODCISECOBJTABLE := :p; BEGIN :r := x.COUNT; END;";
    
    			var parameter = command.CreateParameter();
    			parameter.Direction = ParameterDirection.Input;
    			parameter.ParameterName = "p";
    			parameter.OracleDbType = OracleDbType.Array;
    			parameter.UdtTypeName = "SYS.ODCISECOBJTABLE";
    			parameter.Value =
    				new OdciSecObjTable
    				{
    					Values = new OdciSecObj[]
    					{
    						new OdciSecObj { POBJSCHEMA = "V1", POBJNAME = "V2", OBJSCHEMA = "V3", OBJNAME = "V4" },
    						new OdciSecObj { POBJSCHEMA = "V5", POBJNAME = "V6", OBJSCHEMA = "V7", OBJNAME = "V8" },
    						new OdciSecObj { POBJSCHEMA = "V9", POBJNAME = "V10", OBJSCHEMA = "V11", OBJNAME = "V12" }
    					}
    				};
    			
    			command.Parameters.Add(parameter);
    			
    			var resultParameter = command.CreateParameter();
    			resultParameter.Direction = ParameterDirection.Output;
    			resultParameter.ParameterName = "r";
    			resultParameter.OracleDbType = OracleDbType.Decimal;
    			
    			command.Parameters.Add(resultParameter);
    			
    			command.ExecuteNonQuery();
    			Console.WriteLine(((OracleDecimal)resultParameter.Value).Value);
    		}
    	}
    }
    
    [OracleCustomTypeMapping("SYS.ODCISECOBJTABLE")]
    public class OdciSecObjTable : CustomCollectionTypeBase<OdciSecObjTable, OdciSecObj>
    {
    }
    
    [OracleCustomTypeMapping("SYS.ODCISECOBJ")]
    public class OdciSecObj : CustomTypeBase<OdciSecObj>
    {
    	[OracleObjectMapping("POBJSCHEMA")]
    	public string POBJSCHEMA;
    	[OracleObjectMapping("POBJNAME")]
    	public string POBJNAME;
    	[OracleObjectMapping("OBJSCHEMA")]
    	public string OBJSCHEMA;
    	[OracleObjectMapping("OBJNAME")]
    	public string OBJNAME;
    
    	public override void FromCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		OracleUdt.SetValue(connection, pointerUdt, "POBJSCHEMA", POBJSCHEMA);
    		OracleUdt.SetValue(connection, pointerUdt, "POBJNAME", POBJNAME);
    		OracleUdt.SetValue(connection, pointerUdt, "OBJSCHEMA", OBJSCHEMA);
    		OracleUdt.SetValue(connection, pointerUdt, "OBJNAME", OBJNAME);
    	}
    
    	public override void ToCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		POBJSCHEMA = (string)OracleUdt.GetValue(connection, pointerUdt, "POBJSCHEMA");
    		POBJNAME = (string)OracleUdt.GetValue(connection, pointerUdt, "POBJNAME");
    		OBJSCHEMA = (string)OracleUdt.GetValue(connection, pointerUdt, "OBJSCHEMA");
    		OBJNAME = (string)OracleUdt.GetValue(connection, pointerUdt, "OBJNAME");
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
    
    	public Array CreateArray(int elementCount)
    	{
    		return new TValue[elementCount];
    	}
    
    	public Array CreateStatusArray(int elementCount)
    	{
    		return new OracleUdtStatus[elementCount];
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
