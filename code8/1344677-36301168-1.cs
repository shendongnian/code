    using System;
    using System.Windows.Forms;
    
    static class Keys {}
    
    class Program
    {
        static void Main()
        {
            System.Windows.Forms.Keys key;
            Enum.TryParse("Enter", out key);
            Console.WriteLine(key);
        }
    }
