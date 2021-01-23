     class Program
    {
    
    [DllImport(@"user32.dll")]
    
    static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
    
       static void Main(string[] args)
       {
         // what ever
       }
    }
 
