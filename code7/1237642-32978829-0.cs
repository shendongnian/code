    class Program
    {
        static void Main(string[] args)
        {
            List<Action> actions = new List<Action>();
            actions.Add(() => Program.MakeEarthquake());
            actions.Add(() => Program.CausePlague());
            actions.Add(() => Program.SpaceZombieAttack());
            Random random = new Random();
            int selectedAction = random.Next(0, actions.Count());
            actions[selectedAction].Invoke();
        }
        static void MakeEarthquake()
        {
            Console.WriteLine("Earthquake");
        }
        static void CausePlague()
        {
            Console.WriteLine("Plague");
        }
        static void SpaceZombieAttack()
        {
            Console.WriteLine("Zombie attack");
        }
    }
