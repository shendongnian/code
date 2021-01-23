    public class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
           'Email': 'Joebloggs@example.com',
           'Active': true,
           'CreatedDate': '2015-01-20T00:00:00Z'}";
    
            Account account = JsonConvert.DeserializeObject<Account>(json);
    
            string email=account.Email.ToString();
            DateTime date=account.CreatedDate.ToDateTime();
    
          //Open a connection with database.Write a insert query and provide these values and run the query.
        }
    }
