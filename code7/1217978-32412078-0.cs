    void Main()
    {
    	using (var connection = new OracleConnection("DATA SOURCE=HQ_PDB_TCP;PASSWORD=oracle;USER ID=HUSQVIK"))
    	{
    		connection.Open();
    
    		using (var command = connection.CreateCommand())
    		{
    			command.CommandText = "DECLARE i SYS.ODCICOST := :p; BEGIN :p := SYS.ODCICOST(i.CPUCOST + 1, i.IOCOST + 1, i.NETWORKCOST + 1, i.INDEXCOSTINFO || 'Dummy'); END;";
    			command.BindByName = true;
    			
    			var parameter = command.CreateParameter();
    			parameter.Direction = ParameterDirection.InputOutput;
    			parameter.ParameterName = "p";
    			parameter.OracleDbType = OracleDbType.Object;
    			parameter.UdtTypeName = "SYS.ODCICOST";
    			parameter.Value = new OdciCost { CPUCOST = 123, INDEXCOSTINFO = "DUMMY", IOCOST = 456, NETWORKCOST = 789 };
    			command.Parameters.Add(parameter);
    			
    			command.ExecuteNonQuery();
    			
    			var odciCost = (OdciCost)parameter.Value;
    			Console.WriteLine($"CPUCOST={odciCost.CPUCOST}; IOCOST={odciCost.IOCOST}; NETWORKCOST={odciCost.NETWORKCOST}; INDEXCOSTINFO={odciCost.INDEXCOSTINFO}");
    		}
    	}
    }
    
    [OracleCustomTypeMapping("SYS.ODCICOST")]
    public class OdciCost : IOracleCustomType, IOracleCustomTypeFactory, INullable
    {
    	private bool _isNull;
    	[OracleObjectMapping("CPUCOST")]
    	public decimal CPUCOST;
    	[OracleObjectMapping("INDEXCOSTINFO")]
    	public string INDEXCOSTINFO;
    	[OracleObjectMapping("IOCOST")]
    	public decimal IOCOST;
    	[OracleObjectMapping("NETWORKCOST")]
    	public decimal NETWORKCOST;
    
    	public IOracleCustomType CreateObject()
    	{
    		return new OdciCost();
    	}
    
    	public void FromCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		OracleUdt.SetValue(connection, pointerUdt, "CPUCOST", CPUCOST);
    		OracleUdt.SetValue(connection, pointerUdt, "IOCOST", IOCOST);
    		OracleUdt.SetValue(connection, pointerUdt, "NETWORKCOST", NETWORKCOST);
    		OracleUdt.SetValue(connection, pointerUdt, "INDEXCOSTINFO", INDEXCOSTINFO);
    	}
    
    	public void ToCustomObject(OracleConnection connection, IntPtr pointerUdt)
    	{
    		CPUCOST = (decimal)OracleUdt.GetValue(connection, pointerUdt, "CPUCOST");
    		IOCOST = (decimal)OracleUdt.GetValue(connection, pointerUdt, "IOCOST");
    		NETWORKCOST = (decimal)OracleUdt.GetValue(connection, pointerUdt, "NETWORKCOST");
    		INDEXCOSTINFO = (string)OracleUdt.GetValue(connection, pointerUdt, "INDEXCOSTINFO");
    	}
    
    	public bool IsNull
    	{
    		get { return this._isNull; }
    	}
    
    	public static OdciCost Null
    	{
    		get	{ return new OdciCost { _isNull = true }; }
    	}
    }
