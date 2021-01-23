    using System;
    using Mono.Unix.Native;
    
    namespace killself
    {
    	class MainClass
    	{
    		public static void Main(string[] args)
    		{
    			var currentPID = Syscall.getpid();
    			Syscall.kill(currentPID, Signum.SIGABRT);
    		}
    	}
    }
