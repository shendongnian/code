    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.IO.Pipes;
    
    namespace ConsoleApplication10
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var sending = new AnonymousPipeServerStream(PipeDirection.Out);
    			var receiving = new AnonymousPipeClientStream(PipeDirection.In, sending.ClientSafePipeHandle);
    			var ds = new DoStuff(new StreamReader(receiving));
    
    			System.Threading.Thread.Sleep(500);
    
    			Console.WriteLine("Not sent yet");
    			var other = new StreamWriter(sending);
    
    			other.WriteLine("Hello!");
    			other.Flush();
    
    			Console.WriteLine("Sent");
    
    			Console.ReadLine();
    		}
    	}
    
    	class DoStuff
    	{
    		public DoStuff(StreamReader s)
    		{
    			Task.Run(() =>
    			{
    				Console.WriteLine("About to receive");
    				var k = s.ReadLine();
    				Console.WriteLine("Received");
    				Console.WriteLine(k);
    				Console.WriteLine("Task done");
    			});
    		}
    	}
    }
