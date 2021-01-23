    class Program
    {
    	static void Main(string[] args)
    	{
    		var type = SqlDbType.Bit.ToType();
    		Console.Write(SqlDbType.Bit.ToType().GetDefault().ToString());
    	}
    }
