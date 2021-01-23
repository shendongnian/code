    public class RegistrationModel
    {
        public RegistrationModel()
        {
            Registration = new REGISTRATION();
            AddPayment = true;
        }
        public REGISTRATION Registration { get; set; }
        public bool AddPayment { get; set; }
    
        public SelectList Sections { get; set; }
    
        public SelectList Students { get; set; }
    
        public SelectList Statuses { get; set; }
    }
