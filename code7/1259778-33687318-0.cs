    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class Program
    {
        static async Task<Person> GetPersonAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("GetPersonAsync started.");
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };
            await Task.Delay(5000, cancellationToken); // Wait 5 seconds
            Console.WriteLine("GetPersonAsync ended.");
            return person;
        }
        static async Task TestGetPersonAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("TestGetPersonAsync started.");
            try
            {
                var person = await GetPersonAsync(cancellationToken);
                Console.WriteLine("The person first name:" + person.FirstName);
                Console.WriteLine("The person last name:" + person.LastName);
                Console.WriteLine("TestGetPersonAsync ended.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("TestGetPersonAsync cancelled.");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main started:");
            // let's get person asynchronously;
            // this object will contain our cancellation token;            
            var cts = new CancellationTokenSource();
            // dummy variable here is needed to aviod compiler warning,
            // since TestGetPersonAsync is async, and we will not (and cannot) await it
            var _ = TestGetPersonAsync(cts.Token);
            // if TestGetPersonAsync is not finished yet, we are going to cancel it;
            // wait for a new line
            Console.WriteLine("Press ENTER to cancel TestGetPersonAsync and to exit application.");
            Console.ReadLine();
            if (!_.IsCompleted)
            {
                cts.Cancel();
            }
            Console.WriteLine("Main ended.");
        }
    }
