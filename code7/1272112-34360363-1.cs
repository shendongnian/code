    using ConsoleHotKey;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Democonsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Press ESC to stop.");
                HotKeyManager.RegisterHotKey(Keys.Escape, KeyModifiers.None);
                HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(Console_CancelKeyPress);
                while (true)
                {
                    Console.WriteLine("Voer een getal in : ");
                    string invoer = Console.ReadLine();
                    Console.Write("Voer de macht in waarmee u wilt vermenigvuldigen :");
                    string macht = Console.ReadLine();
                    int getal = Convert.ToInt32(invoer);
                    int getalmacht = Convert.ToInt32(macht);
                    int uitkomst = (int)Math.Pow(getal, getalmacht);
                    Console.WriteLine("De macht van " + getal + " is " + uitkomst + " .");
                    Console.ReadLine();
                }
            }
            static void Console_CancelKeyPress(object sender, HotKeyEventArgs e)
            {
                Environment.Exit(0);
            }
        }
    }
