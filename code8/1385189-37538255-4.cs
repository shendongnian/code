    public class RPMContext : DbContext {
        public RPMContext()
            :this(string.Format("name={0}_RPMContext",ConfigurationManager.AppSettings["Environment"])){}
    
        public RPMContext(string nameOrConnectionString)
            :base(nameOrConnectionString) {
        }  
    }
