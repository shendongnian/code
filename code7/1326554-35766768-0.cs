    public class UsersController : Controller {
      public ActionResult Scores() {
        var connectionString = "your db connection";
        var connection = new SqlConnection(connectionString);
        connection.Open();
    
        var command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT * FROM StackUserScores";
        var reader = command.ExecuteReader();
        var scores = new List<StackUserScores>();
        while( reader.Read()) {
          scores.Add(new StackUserScore {
            Username = reader.GetString(0),
            Password = reader.GetInt(1)
          });
        }
        return View(scores);
      }
    }
