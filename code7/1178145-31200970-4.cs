        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading;
        using System.Diagnostics;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void WriteText(params string[] lines) { WriteText(0, lines); }
    
            static void WriteText(double delaySecs, params string[] lines)
            {
                
                for (int i = 0; i < lines.Length; i++) Console.WriteLine(lines[i]);
                if (delaySecs > 0) Thread.Sleep(TimeSpan.FromSeconds(delaySecs));
            }
    
            static void Main(string[] args)
            {
                Console.Title = "The Secret Agent Test";
                Console.ForegroundColor = ConsoleColor.Green;
                WriteText("Welcome, agent. This is the test to see if\nyou are good enough to be a full member of the OT Secret Agency.", "Do you want to continue? [Y/N]");
                var readk = Console.ReadKey();
                if (readk.Key == ConsoleKey.Y || readk.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    WriteText("Let's continue the test.\n", "Crack the password:\n", "Username: IDIOT_NOOB1337\nPROFILE: Likes memes such as doge.",
                     "Is an elitist (Over the things he likes)", "Only uses the word idiot as an insult", "Password:");
                    string pass1 = Console.ReadLine();
    
                    if (pass1 != "AnyoneWhoDoesn'tLikeDogeIsAnIdiot" && pass1 != "anyonewhodoesn'tlikedogeisanidiot") return;
                    
                    WriteText(2, "Account accessed.", "Stage 1 Complete.", "Loading next level...");                
                    WriteText(1, "Level 2 loaded.");                
                    Console.Clear();
                    WriteText(2.5, "Nice. You certainly have skill. But this test.... determines speed of mind.");                
                    Console.Clear();
                    Console.WriteLine("You only have two seconds to answer the next question. Press any key when ready.");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("What is 12x12?!"); // QUESTION
    
                    int allowedTime = 2 * 1000; // time allowed
                    new Thread(() =>
                    {
                        Stopwatch s = new Stopwatch();
                        s.Start();
                        while (s.ElapsedMilliseconds < allowedTime) { }
                        WriteText(2, "Sorry, you're too late. Restart the test again.");                    
                        Console.Clear();
                        Environment.Exit(-1);
                    }).Start();
    
                    string product = Console.ReadLine();
                    if (product == "144") Console.WriteLine("Impressive. Your mind is fast, too. Well, be prepared for the next test. Pressure.");
    
                    WriteText(2, "Sorry, you are incorrect. Restart the test again.");                
                    Console.Clear();                
                }
            }
        }
    }
