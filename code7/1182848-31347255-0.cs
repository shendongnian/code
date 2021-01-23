    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule(() =>
            {
                // Do something
            }).ToRunEvery(1).Weeks().On(DayOfWeek.Sunday).At(17, 0);
        }
    } 
