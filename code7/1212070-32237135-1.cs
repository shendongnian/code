    public class ZipData
    {
        public ZipData (zip_code_lookup z) 
        {
            this.zip_code = z.zip_code;
            this.full_name = string.Format("{0} {1}",
                                           z.driver_details.first_name,
                                           z.driver_details.last_name);
           this.driver_id = z.driver_id;
           this.zone = z.zone;
        }
    
        public string zip_code { get; set; }
        public string full_name { get; set; }
        public int driver_id { get; set; }
        public string zone { get; set; }
    }
