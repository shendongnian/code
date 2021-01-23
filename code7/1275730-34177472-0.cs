    public class BadClass
    {
        public bool IsIt2016Yet()
        {
            var now = SystemClock.Instance.Now;
            return now.InUtc().Year >= 2016;
        }
    }
