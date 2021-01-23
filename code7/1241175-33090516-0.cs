    namespace MorgSimulator
    {
        class Program
        {
            static void Main(string[] args)
            {
                Morg A = new MorgA();
                A.MovingTime();
    
                Console.ReadKey();
            }
        }
        
        class Morg
        {
            public Morg()
            {}
    
            protected MoveBehavior moveBehavior;
    
            public void MovingTime()
            {
                moveBehavior.move();
            }
        }
        
        class MorgA : Morg
        {
            public MorgA()
            {
                moveBehavior = new Ooze();
            }
        }
        
        interface MoveBehavior
        {
            void move();
        }
        
        class Ooze : MoveBehavior
        {
            private readonly Random randomizer;
            
            public Ooze()
            {
                this.randomizer = new Random();
            }
            
            public void move()
            {
                int row = 40, col = 25;
                Console.CursorVisible = false;
                Console.SetCursorPosition(col, row);
    
                int direction = 0;
    
                for (int i = 0; i < 25; i++)   // count of movement
                {
                    Console.Write("<(._.)>");
                    System.Threading.Thread.Sleep(100);
                    Console.Clear();
    
                    direction = this.randomizer.Next(5);
    
                    while (direction == 0)
                        direction = this.randomizer.Next(5);
    
                    switch (direction)
                    {
                        case 1:
                            if (row + 1 >= 80)
                                row = 0;
                            Console.SetCursorPosition(col, row++);
                            break;
                        case 2:
                            if (row - 1 <= 0)
                                row = 79;
                            Console.SetCursorPosition(col, row--);
                            break;
                        case 3:
                            if (col + 1 >= 50)
                                col = 0;
                            Console.SetCursorPosition(col++, row);
                            break;
                        case 4:
                            if (col - 1 <= 0)
                                col = 49;
                            Console.SetCursorPosition(col--, row);
                            break;
                    }
                }
            }
        }
    }
