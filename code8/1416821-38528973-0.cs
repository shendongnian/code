    using System;
    using System.Collections.Generic;
    
    public class MyClass
    {
    	public static void Main()
    	{
    		ClassIO c = new ClassIO();
    		c.DataReceived();
    		
    		Console.ReadLine();
    	}
    }
    
    public class ClassPlugin
    {
        public delegate void BufferReadyHandler(string str);
        public event BufferReadyHandler OnBufferReady;
        
    	public ClassPlugin()
        {
        }
        
    	public void DataReceived()
        {		
            if (OnBufferReady != null) {
                OnBufferReady("Calling OnBufferReady");
    		}
        }
    }
    
    public class ClassIO : ClassPlugin
    {
        public ClassIO() : base()
        {
            OnBufferReady += ClassIO_OnBufferReady;
        }
    
        private void ClassIO_OnBufferReady(string str)
        {
            Console.WriteLine("Inside ClassIO_OnBufferReady");
        }
    }
