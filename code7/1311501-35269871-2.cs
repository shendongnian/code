    public class DataAccess
    {
        public string IncomingValue { get; set; }
    
        public string SaveToDatabase()
        {
            string valueToSave = IncomingValue;
            
            // Insert into database
    
            return "Success";
        }
    }
