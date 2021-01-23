    public class Level1 : Level0
    {
        public string Data_Level1{get;set;}
        protected override bool OnIsValid()
        {
            return base.OnIsValid() && Data_level1 != null;
        }
    }
    public class Level2 : Level1
    {
        public string Data_Level2{get;set;}
    
        protected override OnLevel1IsValid()
        {
            return base.OnIsValid() && Data_level2 != null;
        }
    }
