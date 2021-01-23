    public class Level1 : Level0
    {
        public string Data_Level1 { get; set; }
        protected override sealed bool OnIsValid()
        {
            if (Data_Level1 == null) return false;
            else return OnLevel1IsValid();
        }
        protected virtual bool OnLevel1IsValid()
        {
            return true;
        }
    }
    public class Level2 : Level1
    {
        public string Data_Level2 { get; set; }
        protected override sealed bool OnLevel1IsValid()
        {
            return Data_Level2 != null;
        }
    }
