    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text.RegularExpressions;
    
    namespace NetworkTracing
    {
    	/// <summary>
    	/// Description of NetworkListner.
    	/// </summary>
    	public class NetworkListner : TraceListener
    	{
    		public static int BytesSent { get; private set;} 
    		public static int BytesReceived { get; private set;}
    		private bool _inSend = false;
    		private bool _inReceived = false;
    		private string _lastMessage = "";
    		private Regex _lengthRegex = new Regex(@"(\[\d*\]) ([\dA-F]*)");
    		public NetworkListner()
    		{
    			BytesSent = 0;
    			BytesReceived = 0;			
    		}
    		
    		private int ExtractNumOfBytes(string message){
    			string lengthUntilThisLineStr = null;
    			try {			
    				var match = _lengthRegex.Match(message);				
    				lengthUntilThisLineStr = match.Groups[2].Value;
    			} catch (ArgumentException ex) {
    				// Syntax error in the regular expression
    			}
    			if (String.IsNullOrEmpty(lengthUntilThisLineStr)) {
    				return 0;
    			}
    			var lengthUntilThisLine = int.Parse(lengthUntilThisLineStr,NumberStyles.HexNumber);
    			return lengthUntilThisLine;
    		}
    		
    		public override void Write(string message) {
    			if (message.Equals("System.Net.Sockets Verbose: 0 : ")) {
    				return;
    			}
    			if (message.Contains("Exiting Socket#")) {
    				int bytes = ExtractNumOfBytes(_lastMessage);
    				if (_inSend) {
    	    			_inSend = false;
    	    			BytesSent += bytes;
    		    	}else if (_inReceived) {
    		    		_inReceived = false;
    		    		BytesReceived += bytes;
    		    	}	
    	    	}			
    			else if (message.Contains("Data from Socket")){
    				if (message.Contains("Send")) {
    					_inSend = true;
    				}
    				else if (message.Contains("Receive")) {
    					_inReceived = true;
    				}
    			}
    			_lastMessage = message;
    	    }
    	
    	    public override void WriteLine(string message) {
    	        Write(message + Environment.NewLine);
    	    }
    	}
    }
