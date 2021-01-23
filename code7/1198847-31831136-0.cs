    [ImplementPropertyChanged]
    public class PersonDetailsPageViewModel
    {
        public Person Person { get; set; }
    
        public void Retrieve()
        {
           try
           {
              using (var con = new SqlConnection(conStr))
              {
                  Person = con.Query<Person>("select firstName,lastName from Person where id = @id", new {id = personId}).First();
              }
           }
           catch (SqlException ex)
           {
               Console.WriteLine("error retrieving due to {0}", ex.Message);
           }
        }
    }
