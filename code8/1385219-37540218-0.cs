    public class RPMContext : DbContext {
        public static string DefaultConnectionString;
        public RPMContext():base(DefaultConnectionString) {
        }   
        public RPMContext(string nameOrConnectionString)
            :base(nameOrConnectionString) {
        }  
    }
