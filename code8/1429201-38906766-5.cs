    public class Shortage
    {
        public Shortage Clone()
        {
            return new Shortage()
            {
                SomeProp = this.SomeProp,
                SomeOtherProp = this.SomeOtherProp
            }
        }
    }
