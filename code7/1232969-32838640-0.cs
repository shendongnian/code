    public class Program
    {
    	public static void Main()
    	{
    		string [] props = {"Parameter Name", "Parameter_Name"};
    		
    		var validNames = props.Select(s=>Sanitize(s)).ToList();
    		Console.WriteLine(String.Join(Environment.NewLine, validNames));
    	}
    	
    	private static string Sanitize(string s)
    	{
    		return String.Join("", s.AsEnumerable()
    						   		.Select(chr => Char.IsLetter(chr) || Char.IsDigit(chr)
    										       ? chr.ToString()      // valid symbol
    										       : "_"+(short)chr+"_") // numeric code for invalid symbol
    						  );
    	}
    }
