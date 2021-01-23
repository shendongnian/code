    public class Ans34612672
    {
        public Ans34612672()
        {
        }
        public bool Execute()
        {
            bool retValue = false;
            scoremanager Manager = new scoremanager();
            Manager.Start();
            while(Manager.score < 20)
            {
                Manager.Update();
            }
            Console.WriteLine(Manager.distance);
            Console.ReadKey();
            return retValue;
        }
    }
