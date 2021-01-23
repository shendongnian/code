    public class Program
    {
        public delegate bool delIsDone(int curState, int needState);
                           
        public static bool checkNumbers(int a, int b)
        {
            return a < b;
        }
            
        public static void Main(string[] args)
        {
            var t = new ProgressChecker(new delIsDone(checkNumbers)); 
        // OR var t = new ProgressChecker(new delIsDone((a, b) => { return a < b; }));           
        }
    }
