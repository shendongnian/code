    class VArray : IOracleCustomType, INullable
    {
    	[OracleArrayMapping()]
    	public Int32[] Array;
    
    	private OracleUdtStatus[] m_statusArray;
    	public OracleUdtStatus[] StatusArray
    	{
    		get
    		{
    			return this.m_statusArray;
    		}
    		set
    		{
    			this.m_statusArray = value;
    		}
    	}
    
    	private bool m_bIsNull;
    
    	public bool IsNull
    	{
    		get
    		{
    			return m_bIsNull;
    		}
    	}
    
    	public static VArray Null
    	{
    		get
    		{
    			VArray obj = new VArray();
    			obj.m_bIsNull = true;
    			return obj;
    		}
    	}
    
    	public void ToCustomObject(OracleConnection con, IntPtr pUdt)
    	{
    		object objectStatusArray = null;
    		Array = (Int32[])OracleUdt.GetValue(con, pUdt, 0, out objectStatusArray);
    		m_statusArray = (OracleUdtStatus[])objectStatusArray;
    	}
    
    	public void FromCustomObject(OracleConnection con, IntPtr pUdt)
    	{
    		OracleUdt.SetValue(con, pUdt, 0, Array, m_statusArray);
    	}
    
    	public override string ToString()
    	{
    		if (m_bIsNull)
    			return "VArray.Null";
    		else
    		{
    			string rtnstr = String.Empty;
    			if (m_statusArray[0] == OracleUdtStatus.Null)
    				rtnstr = "NULL";
    			else
    				rtnstr = Array.GetValue(0).ToString();
    			for (int i = 1; i < m_statusArray.Length; i++)
    			{
    				if (m_statusArray[i] == OracleUdtStatus.Null)
    					rtnstr += "," + "NULL";
    				else
    					rtnstr += "," + Array.GetValue(i).ToString();
    			}
    			return "VArray(" + rtnstr + ")";
    		}
    	}
    }
    
    [OracleCustomTypeMapping("SYS.ODCINUMBERLIST")]
    public class VArrayFactory : IOracleCustomTypeFactory, IOracleArrayTypeFactory
    {
    	// IOracleCustomTypeFactory
    	public IOracleCustomType CreateObject()
    	{
    		return new VArray();
    	}
    
    	// IOracleArrayTypeFactory Interface
    	public Array CreateArray(int numElems)
    	{
    		return new Int32[numElems];
    	}
    
    	public Array CreateStatusArray(int numElems)
    	{
    		// CreateStatusArray may return null if null status information 
    		// is not required.
    		return new OracleUdtStatus[numElems];
    	}
    }
