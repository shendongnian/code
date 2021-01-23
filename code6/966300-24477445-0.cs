    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz();
            quiz.Quiz1();
        }
    }
    class Quiz
    {
        List<Action> methods = new List<Action>();//List of action delegates
        Random random = new Random();//Random instance
      
        public Quiz()
        {
           //Populate the List with your methods
            methods.Add(()=>Quiz1());
            methods.Add(()=>Quiz2());
            methods.Add(()=>Quiz3());
        }
        public void Quiz1() //Removed Static
        {
           // Program.DefaultMethod(2, 3); //This method from Program class
            Console.WriteLine("What is this?");
            Console.WriteLine("│ .. / .- -- / .--. .-. --- --. .-. .- -- -- . .-.");
            Console.WriteLine("│ (hint: sound)");
            if (Text.Answer(2, 7, 2, 8, "I AM PROGRAMMER", "I am programmer", "i am programmer", 3)) //This method from Text class  
            {
                int r = random.Next(methods.Count());//Get a random number
                methods[r]();//Call the method using the random number
            }
            else
           {
           GameOver();
           }
        }
        public void Quiz2()
        {
          //  Program.DefaultMethod(2, 3); //This method from Program class
            Console.WriteLine("2 - 4 - 12 - 44 - ?");
            if (Text.Answer(2, 6, 2, 7, "172", "172", "172", 3)) //This method from Text class
            {
                int r = random.Next(methods.Count());//Get a random number
                methods[r]();//Call the method using the random number
            }
       else
      {
      GameOver
      }
        }
        public void Quiz3()
        {
          //  Program.DefaultMethod(2, 3); //This method from Program class
            Console.WriteLine("If MACHINE is LBBIHOD");
            Console.WriteLine("│ So PROGRAM is....");
            if (Text.Answer(2, 7, 2, 8, "OSNHQBL", "osnhqbl", "Osnhqbl", 3)) //This method from Text class
            {
                int r = random.Next(methods.Count());
                methods[r]();
            }
        }
        //Sorry I just copy 3 question. Because I have so many question XD
    }
    class Text
    {
        
        public static void Word(string Teks, int x, int y, ConsoleColor wt, ConsoleColor wb)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = wt;
            Console.BackgroundColor = wb;
            Console.Write(Teks);
        }
        //Now your Answer method returns a bool indicating if the user will continue answering more questions or is it GameOver
        public static bool Answer(int x1, int y1, int x2, int y2, string correctanswer1, string correctanswer2, string correctanswer3, int count)
        {
            //Quiz[] kuis = {Quiz1(), Quiz2(), Quiz3()}
            //I TRY TO MAKE LIKE ABOVE BUT MAYBE IT'S NOT LIKE THAT
            Console.SetCursorPosition(x1, y1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Your answer : ");
            string answer;
            int chance = 0;
            do
            {
                Console.SetCursorPosition(x2, y2);
                Console.WriteLine("                                                                          ");
                Console.SetCursorPosition(x2, y2);
                answer = Console.ReadLine();
                chance++;
                if (answer != correctanswer1 || answer != correctanswer2 || answer != correctanswer3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x2, y2 + 1);
                    Console.WriteLine("Sorry, your answer is incorrect...");
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey(true);
                    Console.SetCursorPosition(x2, y2 + 1);
                    Console.WriteLine("                                   ");
                }
            } while (chance < count && answer != correctanswer1 || answer != correctanswer2 || answer != correctanswer3);
            if (answer == correctanswer1 || answer != correctanswer2 || answer != correctanswer3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x2, y2 + 1);
                Console.WriteLine("Congratulation! Your answer is correct...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                
                return true;//Return to Quiz Class
            }
            else
            {
                return false;
                
                // GameOver();
            }
        }
    }
    }
