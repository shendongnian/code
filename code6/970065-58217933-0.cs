	public class FileParser
	{
		public static Dictionary<string, Delegate> customParsingCallbacks  = new Dictionary<string, Delegate>();
		
		delegate string delegate1(int x, int y);
		delegate int delegate2(string str1);
		
		static FileParser()
		{
			customParsingCallbacks["points"] = new delegate1(geometryContentParser);
			customParsingCallbacks["period"] = new delegate2(function2);
		} 
		
		private bool string geometryContentParser(int x, int y)
		{
			if (formattedLine.Contains("}"))
            {
                return false;
            }
            return true;
		}	
		
		private static int function2(string str1)
		{
			int result = 1;
			return result;
		}
	}
	
