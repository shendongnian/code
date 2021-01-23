    using System.Data;
    using System.Configuration;
    using Entities;
    namespace DataAccess
    {
    public class DataLiftingStory
    {
        public bool insertLifting(LiftingStory obj) //correction: should be LiftingStory instead of DataLiftingStory because I'm retrieving a LiftingStory objecto to be proccesed.
        {
            //we're creating a new connection to Database, but it will need string parameter
            //you can get it directly from the connectionstring on the Web.config in this way
            // ConfigurationManager.ConnectionStrings["nameParameterOfYourConnString"].ConnectionString
            //instead of that I'll do it with a string for making more easier to understand
            string connectionString = "Data Source=WINSERVER;Initial Catalog=TRAINING;Integrated Security=SSPI;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //now I'll create the command
                using (SqlCommand command = new SqlCommand())
                {
                    //so now I've to say what type of command I'm making up. In your case is "Text" because you're being explicit with the query
                    //I suggest you to use stored procedures btw.
                    command.CommandType = CommandType.Text;
                    //now the command text will be your query
                    command.CommandText = "INSERT INTO LIFT_HISTORY VALUES(@date,@lift,@weight,@reps,@week)";
                    //now we set the parameters
                    command.Parameters.Add(new SqlParameter("date", obj.Date));
                    command.Parameters.Add(new SqlParameter("lift", obj.Lift));
                    command.Parameters.Add(new SqlParameter("weight", obj.Weight));
                    command.Parameters.Add(new SqlParameter("reps", obj.Reps));
                    command.Parameters.Add(new SqlParameter("week", obj.Week));
                    try
                    {
                        command.Connection = connection;
                        command.Connection.Open();
                        //now we're executing the query and if we get more than 0 that will means that it inserted or modified a row
                        //then it will return true and going out from method.
                        if (command.ExecuteNonQuery() > 0)
                            return true;
                    }
                    catch (Exception)
                    {
                        //If it fails return false
                        return false;
                        throw;
                    }
                    finally
                    {
                        //then we close the connection
                        command.Connection.Close();
                    }
                
                //if not failed but it didn't anything, it will return false
                return false;
                }
            }
        }
