    public class YourClass
    {
        public IEnumerable<IMoveOptionCalcumator> MoveOptionCalculators { get; set; }
    
        public YourClass()
        {
            // Initialize the collection of calculators 
            // You can look into Dependency Injection if you want even another step forward :)
        }
        public IEnumerable<int> movepion(schaken.pion pion, int row, int column)
        {
            List<MoveOption> options = new List<MoveOption>();
            foreach (var item in MoveOptionsCalculators)
            {
                var result = item.Calculate(/*input*/);
                if(result != null)
                {
                    options.Add(result);
                }
            }
            return options;
        }
    }
