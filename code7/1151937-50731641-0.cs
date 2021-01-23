    using System;
    using System.IO;
    
    namespace ConsoleApplication1{
        class Program{
            public static int Main(){
                Program.determineAgeDifference dta = new Program.determineAgeDifference();
    
                string[] input = new string[2];
    
                Console.Write("So, what's your name?\n\n>> ");
                input[0] = Console.ReadLine();
    
                Console.Clear();
    
                Console.Write("How old are you?\n\n>> ");
                input[1] = Console.ReadLine();
    
                Console.WriteLine(dta(int.Parse(input[1].TrimStart(' ').TrimEnd(' ')));
                Console.ReadLine();
    
                return 0;
            }
            private string determineAgeDifference(int age){
                 string returnValue = "";
    
                if (age < 12){
                    returnValue = "I'm older than you. I'm 12!";
                }
                else if (age == 12){
                    returnValue = "We are the same age!!!";
                }
                else{
                    returnValue = ("You're " + (age - 12).ToString() + "Years older than me!");
                }
    
                return returnValue;
            }
        }
    }
