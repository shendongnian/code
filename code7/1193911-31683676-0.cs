    class DetailForm : Form
    {
        public string ID { get; set; }
        // ... other fields/properties
        
        public DetailForm(int id) : base()
        {
            ID = id;
        }
        // ... other methods
    }
