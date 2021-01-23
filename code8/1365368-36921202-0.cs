       class Program
   {
      public static IEnumerable<Tuple<string, string, string> > AllUserInformation(Dictionary<string, string> addressBook, Dictionary<string, string> usersAndManagersList)
      {
         foreach (var book in addressBook)
         {
            string managerEmail;
            if (usersAndManagersList.TryGetValue(book.Value, out managerEmail))
            {
               yield return Tuple.Create(book.Key, book.Value, managerEmail);
            }
            else
            {
               yield return Tuple.Create(book.Key, book.Value, string.Empty);
            }
         }
      }
      static void Main(string[] args)
      {
         Dictionary<string, string> addressBook = new Dictionary<string, string>();
         Dictionary<string, string> usersAndManagersList = new Dictionary<string, string>();
         addressBook.Add("Andy", "andy@firm.com");
         addressBook.Add("Mary", "mary@firm.com");
         usersAndManagersList.Add("andy@firm.com", "jane@firm.com");
         foreach (var allInfo in AllUserInformation(addressBook, usersAndManagersList))
         {
            Console.WriteLine("User: {0}, User's Email: {1}, Manager's Email: {2}", allInfo.Item1, allInfo.Item2, allInfo.Item3);
         }
      }
