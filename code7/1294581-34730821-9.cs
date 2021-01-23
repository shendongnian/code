    internal class MyBotProxy : IAIParam
    {
        public int Previous
        {
            get { return PreviousCalls.previousBot1Call; }
            set { PreviousCalls.previousBot1Call = value; }
        }
    }
