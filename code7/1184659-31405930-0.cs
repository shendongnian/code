    void Main()
    {
    	var ce = new CustomException("uh oh", 1001);
    	Console.WriteLine(ce.HResult);
    	// Convert integer as a hex in a string variable
    	string hexValue = ce.HResult.ToString("X");
    	// Convert the hex string back to the number
    	int decAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);		
    	Console.WriteLine(hexValue);
    	Console.WriteLine(decAgain);
    }
    
    
    public class CustomException : Exception
    {
        public CustomException(string message, int errorCode) : base(message)
        {
    		base.HResult = (int)((uint)0x88880000 + errorCode);
        }
    }
