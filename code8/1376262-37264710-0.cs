    public class OverviewViewModel {
    
        public string chain_name { get; set; }
        public int store_id { get; set; }
        public int total_attempts { get; set; }
        public int total_unique_number_called { get; set; }
        public int total_callable { get; set; }
        public int total_completed_interviews { get; set; }
        public decimal? unique_number_per_complete { get; set; }
    
        public OverviewViewModel()
        {
            unique_number_per_complete = 0;
        }
    public OverviewViewModel(Overview record)
        {
            store_id = record.store_id;
    
        chain_name = record.chain_name;
    
        total_attempts = record.total_attempts;
    
        total_callable = record.total_callable;
        //etc
        }
    }  
