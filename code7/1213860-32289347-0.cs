    public class Program
    {
        static int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        const int MONTHS_IN_YEAR = 12;
        
        public void Main(string[] args)
        {
            int[,] rain = new int[31, MONTHS_IN_YEAR];
            MakeItRain(rain);
        }
        
        static void MakeItRain(int[,] rainfall)
        {
            Random Rainfall = new Random(10);
            Random RainOrNot = new Random(10);
            for (int j = 0; j < MONTHS_IN_YEAR; j++)
            {
                for (int i = 0; i < (daysInMonth[j]); i++)
                {
                    if (RainOrNot.Next(1, 5) == 1)
                    {
                        rainfall[i,j] = Rainfall.Next(1, 28);
                    }
                }
            }
        }
    }
