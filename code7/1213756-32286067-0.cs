    public class Calc
    {
        public int CurrentValue { get; set; }
    
        public void Add(int number)
        {
            this.CurrentValue = this.CurrentValue + number;
        }
    }
