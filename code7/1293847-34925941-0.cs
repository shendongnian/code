    public class Program
    {
        public int WeldCount;
        public int ConnectroCount;
        public List<float> section = new List<float>();
        //public List<> TrackElements = new List<>();
        public Program()
        {
            section.Add(0);
            
        }
        public void showResults()
        {
            float allSections = 0;
            foreach (float item in section)
            {
                allSections += item;
            }
            Console.Clear();
            Console.WriteLine("c1 {0}, c2 {1}, c3{2}", WeldCount,ConnectroCount,allSections);
            Console.ReadKey();
        }
        public void finalConstruction()
        {
        }
        public static void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("Add: \n1. Section \n2. Weld \n3. Regenerator\n4. Show results");
            
        }
        public void menuChoose()
        {
            var key = Console.ReadKey();
            
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    Console.WriteLine("Give lenght:");
                    float result;
                    float.TryParse(Console.ReadLine(), out result);
                    
                    section.Add(result);
                    mainMenu();
                    menuChoose();
                    break;
                case ConsoleKey.D2:
                    WeldCount++;
                    mainMenu();
                    menuChoose();
                    break;
                case ConsoleKey.D3:
                    ConnectroCount++;
                    mainMenu();
                    menuChoose();
                    break;
                case ConsoleKey.D4:
                    showResults();
                    mainMenu();
                    menuChoose();
                    break;
                default:
                    Console.WriteLine("wtf did just happend");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            mainMenu();
            program.menuChoose();
            
        }
    }
    }
