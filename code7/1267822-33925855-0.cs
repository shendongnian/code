    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args) {
            Menu();
        }
        static void Menu() {
            //Get the maximum number of columns in the console.
            //If this is 80, subtract 1 as the columns start from 0, not 1,
            //ie, 0 - 79 = 80 columns in total.
            int MaxWidth = Console.BufferWidth - 1;
            Random random = new Random();
            sbyte X = 1;
            sbyte Y = 20;
            float randomNumber;
            /**
             Don't use a loop which says while(true), or you will have to do tests inside the loop
             to see where it should end.
             We know how many columns the console has, so stop the loop when X is too big to increment
             within that limit.
             */
            while (X < MaxWidth) {
                randomNumber = random.Next(0, 100);
                /**
                You only need to check for a condition that will cause a change.
                If you have a check which results in Y = Y, you're adding code that won't be run.
                So, instead of saying if (y >= 10) { Y = Y } else { do something },
                flip it around and say if ( y <= 10 ) { do something } 
                 * **/
                if (randomNumber < 50) {
                    if (Y <= 10) {
                        Y++;
                    }
                } else if (randomNumber > 50) {
                    if (Y <= 30) {
                        Y--;
                    }
                }
                X++;
                PrintToScreendynamic(X, Y, "-");
                Thread.Sleep(200);
            }
        }
        static void PrintToScreendynamic(sbyte X, sbyte Y, string text) {
            Console.SetCursorPosition(X, Y);
            Console.Write(text);
        }
    }
}
