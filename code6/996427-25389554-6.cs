    public abstract partial class ReportsController()
    {
        public ComplexProperties Properties {get; private set;}
        public ReportsController(ComplexProperties properties)
        {
            Properties=properties;
            CheckProperties();
        }
     }
