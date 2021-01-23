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
            static void WriteText(params string[] lines)
            {
                for (int i = 0; i < lines.Length; i++) Console.WriteLine(lines[i]);
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
    
                    WriteText("Account accessed.", "Stage 1 Complete.", "Loading next level...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Level 2 loaded.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Nice. You certainly have skill. But this test.... determines speed of mind.");
                    Thread.Sleep(2500);
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
                        Console.WriteLine("Sorry, you're too late. Restart the test again.");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Environment.Exit(-1);
                    }).Start();
    
                    string product = Console.ReadLine();
                    if (product == "144") Console.WriteLine("Impressive. Your mind is fast, too. Well, be prepared for the next test. Pressure.");
    
                    Console.WriteLine("Sorry, you are incorrect. Restart the test again.");
                    Thread.Sleep(2000);
                    Console.Clear();                
                }
            }
        }
    }
