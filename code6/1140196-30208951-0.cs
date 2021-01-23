    using System.Collections.Generic;
    using FX.Configuration;
    namespace JsonConfigurationConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                var config = new Users();
            }
        }
        public class Users : JsonConfiguration
        {
            public List<User> users { get; set; }
        }
        public class User
        {
            public string name { get; set; }
        }
    }
