    public class RowData
    {
        public String Company { get; set; }
        public String Number { get; set; }
        public String Description { get; set; }
    
        public RowData(String company, String number, String description)
        {
            Company = company;
            Number = number;
            Description = description;
        }
    }
