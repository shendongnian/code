    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var stringToCheck = "hi there";
    		
    		Console.WriteLine("Checksum for " + stringToCheck + ": " + CalcChecksum(stringToCheck, stringToCheck.Length));
    	}
    	
    	static int CalcChecksum(string packet, int packetLength)
    	{
    		char checksum = (char)0;
    		
    		for (int i = 0; i < packetLength; i++)
    		{
    			checksum ^= packet[i];
    		}
    		
    		return checksum;
    	}
    }
