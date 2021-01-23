    public class Question
    {
        public int QuestionID { get; set; }
        public String Description { get; set; }
    }
    
    public class Answer
    {
        public int AnswerID { get; set; }
        public int QuestionAnswerID { get; set; }
        public String Description { get; set; }
    }
    
    public Class QuestionRepository : YourDbConnection
    {
        public List<Question> getQuestions()
        {
            List<Question> question = new List<Question>();
            String sql = "SELECT * FROM question";
            Connection connection = getYourDbConnection();
            Command command = connection.CreateCommand();
            command.CommandText = sql;
            DataReader reader = null;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                     Question q = new Question();
                     q.QuestionID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("QUESTION_ID")));
                     q.Description = reader.GetValue(reader.GetOrdinal("DESCRIPTION")).ToString();
                     questions.Add(q);
                }
                reader.Close();
                connection.Close();
            }
            catch(Exception ex) //readers don't throw database exceptions when attempting to get info by index
            {
                if(reader != null)
                    if(!reader.IsClosed)
                        reader.Close();
                connection.Close();
                logger.error("Failed to retrieve questions from the database.", ex);
            }
            return questions;
        }
    }
