    [PerOperationThrottleBehavior]
    public class Service1 : IService1
    {
        public string register(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
