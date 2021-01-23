    public class classx
    {        
        public string[] Places = new string[] { "Berlin", "Paris", "London", "Rome", "Tirana", "Istanbul" };
        public int[] Kilometers = new int[] { 50, 30, 70, 110, 40, 90 };
        public TimeSpan Times(string input) //note the input string here
        {
            double length = 0; double hour = 0, minute = 0, seconds = 0; int hour1 = 0, minute1 = 0, second1 = 0;
            //Form1 form1 = new Form1(); //you don't need this
    
            for (int i = 0; i <= 5; i++)
            {
                //this is the row which doesn't work
                if (input == Places[i]) //now you use input here
                {
                    length = Kilometers[i];
                }
            }
            hour = (length / 80);
            hour1 = Convert.ToInt32(Math.Truncate(hour));
            minute = (hour - Math.Truncate(hour)) * 60;
            minute1 = Convert.ToInt32(Math.Truncate(minute));
            second = (minute - Math.Truncate(minute)) * 60;
            second1 = Convert.ToInt32(Math.Truncate(second));
            TimeSpan time = new TimeSpan(Convert.ToInt32(hour), Convert.ToInt32(minute1), Convert.ToInt32(second1));
            TimeSpan TimeLength = new TimeSpan(hour1, minute1, second1);
            return TimeLength;
        }
    }
