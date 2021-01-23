    public class Program
    {
    	static void Main(string[] args)
    	{
    		string ip = "192.168.232.189";
    		string ipHexFormat = string.Format("{0:X}", ConvertIpToNumber(ip));
    
    		Console.WriteLine(ipHexFormat);
    	}
    
    	public static long ConvertIpToNumber(string dottedIpAddress)
    	{
    
    		long num = 0;
    		if (dottedIpAddress == "")
    		{
    			return 0;
    		}
    		else
    		{
    			int i = 0;
    			string[] splitIpAddress = dottedIpAddress.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
    			for (i = splitIpAddress.Length - 1; i >= 0; i--)
    			{
    				num += ((long.Parse(splitIpAddress[i]) % 256) * (long)Math.Pow(256, (3 - i)));
    			}
    			return num;
    		}
    	}
    }
