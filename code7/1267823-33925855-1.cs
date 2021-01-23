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
            //The console starts at the top-left corner from point 0,0 (row 0, column 0).
            //To find the number of columns, use the property Console.BufferWidth.
            //This returns the number of characters which can be displayed on a single line from left to right.
            //For example, If the number of columns is 80, the columns are numbered from 0 to 79, so the highest possible value of X is 79.
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
                    //If Y is greater than or equal to 10, make Y smaller by 1.
                    //This prevents the cursor from moving to a line closer
                    //to the top of the console than Line 10.
                    if (Y >= 10) {
                        Y--;
                    }
                } else if (randomNumber > 50) {
                    //If Y is less than or equal to 30, make Y largerby 1.
                    //This prevents the cursor from moving to a line closer
                    //to the bottomof the console than Line 30.
                    if (Y <= 30) {
                        Y++;
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
