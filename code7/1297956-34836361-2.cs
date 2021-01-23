    using System;
    using System.Net;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var wants = new WantsByte();	
    	}
    }
    
    class HasByte
    {
    	public byte[] theByteArray = new byte[4];
    	
    	public HasByte(IPAddress someAddress)
    	{
    		theByteArray = someAddress.GetAddressBytes();
    	}
    }
    
    class WantsByte
    { 
        IPAddress address = IPAddress.Parse("192.168.1.1");
    	HasByte theInstance;
    
    	public WantsByte()
    	{
    		theInstance = new HasByte(this.address);
    		
    		// do something with theInstance.theByteArray[2] for example
    		// Let's print all elements of the array
    		Console.WriteLine(String.Join(",", theInstance.theByteArray.Select(o => o.ToString()).ToArray()));
    	}
    }
