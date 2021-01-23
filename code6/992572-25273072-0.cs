    public class AxiomDS
    {
        public DateTime time { get; set; }
        public string CC { get; set; }
        public string term { get; set; }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            List<AxiomDS> resultAxiomData = new List<AxiomDS>();
    
            var uniqueTimes = resultAxiomData.Select(a => a.time).Distinct();
    
            foreach (var uniqueTime in uniqueTimes)
            {
                // Find all records that have this time
                var recordsToProcess = resultAxiomData.Where(r => r.time == uniqueTime);
    
                // TODO:
                foreach (var record in recordsToProcess)
                {
                    // Do something with this list
                }
            }
        }
    }
