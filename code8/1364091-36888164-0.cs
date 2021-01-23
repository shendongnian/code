             static void Main(string[] args)
            {
                Manager mngr = new Manager();
            }
        }
        public abstract class Position
        {
            public abstract string Title { get; }
            public Position()
            {
            }
        }
        public class Manager : Position
        {
            public override string Title
            {
                get
                {
                    return "Manager";
                }
            }
        }
