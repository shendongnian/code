    using System;
    using System.Net;
    using System.Net.NetworkInformation;
    
    public class Program
    {
    	public static void Main()
    	{
    		Ping ping = new Ping();
    		//change the following ip variable into the ip adress you are looking for
    		string ip = " ";
    		IPAddress address = IPAddress.Parse(ip);
    		PingReply pong = ping.Send(address);
    		if (pong.Status == IPStatus.Success)
    		{
    			Console.WriteLine(ip + " is up and running.");
    		}
    	}
    }
