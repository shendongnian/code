    public class Phone
    {
        public Phone()
        {
            Model = new Model();
        }
        public string Name {get; set;}
        public Model Model {get; set;}
    }
    
    public class Model
    {
        public string Name {get; set;}
        public string IMEI {get; set;}
    }
