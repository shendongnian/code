    using System;
    using System.Net;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var wants = new WantsByte();
    		wants.DoSomethingWithHasByte();
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
        static IPAddress address = IPAddress.Parse("192.168.1.1");
    	 
    	HasByte theInstance = new HasByte(WantsByte.address);
    	
    	public void DoSomethingWithHasByte()
    	{
    		Console.WriteLine(String.Join(",", theInstance.theByteArray.Select(o => o.ToString()).ToArray()));
    	}
    }
