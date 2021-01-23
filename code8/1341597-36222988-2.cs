    using System;				
    public class Program
    {
    	public static void Main()
    	{
        	foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
    			Console.WriteLine("{ \"" + timeZone.Id + "\",\" " + timeZone.DisplayName + "\" },");
        }
    }
