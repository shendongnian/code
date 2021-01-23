    using System;
    using System.Speech; // <-- sounds like what you are using, not necessary for this example
    using System.Speech.Recognition; // <--- you need this
    
    namespace ConsoleApplication2
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			using (SpeechRecognizer recognizer = new SpeechRecognizer())
    			{
    				// do something
    			}
    		}
    	}
    }
