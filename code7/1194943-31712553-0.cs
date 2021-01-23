     namespace PracticeCSharp
     {    
        class Program
        {
        
        
            static void Main(string[] args)
            {
                Player test = new Player();
                test.Score = 5;
                Console.ReadLine();
            }
        
        }
        class Player
        {
            private int _score;
            public int Score
            {
                get
                {
                    return _score;
                }
                set
                {
                    _score = value;
                }
            }
        }
    }
