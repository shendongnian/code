    using System;
    using System.Linq;
    using System.Net;
    using DotRas;
    
    namespace Test_Reconnect_PPPoE
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			// Connect
    			using (RasDialer dialer = new RasDialer())
    			{
    				dialer.EntryName = "Your Entry (Connection Name)";
    				dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User);
    				dialer.Credentials = new NetworkCredential("username", "password");
    				dialer.Dial();
    				Console.WriteLine("Connected");
    			}
    			// Disconnect
    			RasConnection conn = RasConnection.GetActiveConnections().Where(o => o.EntryName == "Your Entry (Connection Name)").FirstOrDefault();
    			if (conn != null)
    			{
    				conn.HangUp();
    				Console.WriteLine("Disconnected");
    			}
    			Console.ReadKey();
    		}
    	}
    }
