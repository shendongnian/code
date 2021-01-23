    public class Company
    {
        [Category("Main")]
        [DisplayName("Name")]
        [Description("Property description")]
        public String Name { get; set; }
        [Category("Main")]
        [DisplayName("Type")]
        [Description("Property description")]
        public String Type { get; set; }
        [Category("Main")]
        [DisplayName("Something")]
        [Description("Property description")]
        public bool Something { get; set; }
        [Category("Main")]
        [DisplayName("Director")]
        [Description("Property description")]
        [ItemsSource(typeof(EmployeList))]
        public Employe Director { get; set; }
    }
