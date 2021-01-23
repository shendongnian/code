    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>() {
                new Contact() { ColumnID=2, FirstName = "Peter", LastName="Jackson"},
                new Contact() { ColumnID=1, FirstName = "Jhon", LastName="Smith"},
                new Contact() { ColumnID=3, FirstName = "Venu", LastName="Prasad"},
                new Contact() { ColumnID=4, FirstName = "Patrick", LastName="Jane"},
            };
            string TheSearchParameter = "Jhon Smith";
            var result = (from c in contacts
                         where (TheSearchParameter.Split(' ').Contains(c.FirstName) ||
                     TheSearchParameter.Split(' ').Contains(c.LastName))
                         select c.ColumnID).Distinct().ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public class Contact
        {
            public int ColumnID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
