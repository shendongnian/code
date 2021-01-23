    namespace DiceRoll
    {
        public class RollClass
        {
            //int die1, die2, counter;  // <-- Field of class should be defined outside method.
                                        // <-- And since you used auto generated property below, these are not needed here.
            public void RollMethodDice()
            {
                // create Random number generator
                Random rndRoll = new Random();
                // Loop that counts the # of rolls from 1 to 100
                for (counter = 1; counter <= 100; counter++) {
                    // Random generators for each die
                    die1 = rndRoll.Next(1, 7);
                    die2 = rndRoll.Next(1, 7);
                }
            }
            public int GetDiceRoll()
            {
                return die1;
                //return die2;  // <-------- You cannot return multiple values in a method.
                //return counter;  // <----- Instead, an array point/reference is possible.
            }
            public int die1 { get; set; }
            public int die2 { get; set; }
            public int counter { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to the dice rolling program.");
                Console.WriteLine();
                Console.WriteLine("This program will roll dice 100 times and display the roll where doubles land.");
                Console.WriteLine();
                Console.WriteLine("Rolls that were in doubles:");
                RollClass myRollClass = new RollClass();
                myRollClass.RollMethodDice();
                if (myRollClass.die1 == myRollClass.die2)  // <--- You need use your class instance to access the property.
                {
                    Console.WriteLine("Roll " + myRollClass.counter + ": " + myRollClass.die1 + " " + myRollClass.die2);
                }
                // Key stroke is needed to close console window so results are visible
                Console.ReadKey();  // <--------- Method call should be stay inside a method, not a class.
            }
        }
    }
