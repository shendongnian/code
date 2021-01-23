     public class Login : ICustomer
        {
            public string Name { get; set; }
            public string pdw { get; set; }
        }
        public interface ICustomer
        {
            string Name { get; set; }
            string pdw { get; set; }
        }
