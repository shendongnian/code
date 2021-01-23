    class MyStreamWriter
    {
       private StreamWriter sw;
       // Constructor
       public MyStreamWriter(Stream socketStream)
       {
          sw = new StreamWriter(socketStream);
       }
       // Example function
       public void WriteLine(string myText)
       {
         Trace.WriteLine(myText);
         sw.WriteLine(myText);
       }
    }
