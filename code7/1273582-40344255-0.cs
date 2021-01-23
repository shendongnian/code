    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using JulMar.Atapi;
    namespace SimpleCall
    {
        class Program
    {
        static void Main(string[] args)
    {
        TapiManager z = new TapiManager("SimpleCall");
        z.Initialize();
        TapiLine[] phone = z.Lines;
        TapiLine line = phone[16];
        Console.WriteLine(line);
        line.Open(MediaModes.Modem);
        Console.WriteLine(line.Capabilities.MediaModes);
    }
    }
    }
