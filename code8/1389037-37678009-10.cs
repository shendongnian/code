    public class UsersController : ApiController {
    
        //eg: POST api/users/post
        [HttpPost]
        public IHttpActionResult Post(PersonModel person) {
            if (person == null) return BadRequest();
            try
            {        
                SqlConnection connection = new SqlConnection("Data Source=198.71.226.6;Integrated Security=False;User ID=AtallahMaroniteDB;Password=a!m?P@$$123;Database=AtallahPlesk_;Connect Timeout=15;Encrypt=False;Packet Size=4096");
        
                String query = "INSERT INTO Members(LastName, FirstName, Gender, MobileNumber, EmailAddress, Job, Address) VALUES " +
                "(@LastName, @FirstName, @Gender, @MobileNumber, @EmailAddress, @Job, @Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@LastName", person.LastName);
                command.Parameters.Add("@FirstName", person.FirstName);
                command.Parameters.Add("@Gender", person.Gender);
                command.Parameters.Add("@MobileNumber", person.MobileNumber);
                command.Parameters.Add("@EmailAddress", person.EmailAddress);
                command.Parameters.Add("@Job", person.Job);
                command.Parameters.Add("@Address", person.Address);
        
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return InternalServerError();
            }
            return Ok();
        }
    }
