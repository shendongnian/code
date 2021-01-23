    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            var json = "{'Id': 1, 'Salary': 100 }";
            var settings = new JsonSerializerSettings
            {
                Error = Error,
                MissingMemberHandling = MissingMemberHandling.Error
            };
            var person = JsonConvert.DeserializeObject<Person>(json, settings);
            Console.ReadKey();
        }
        private static void Error(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine(errorEventArgs.ErrorContext.Error.Message);
            errorEventArgs.ErrorContext.Handled = true;
        }
    }
