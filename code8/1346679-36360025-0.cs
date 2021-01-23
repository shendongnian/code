    public class TestAnswers
    {
        public string FirstName, LastName, Version;
        public int StudentId, Score;
        public string[] Answers;
    
        public TestAnswers(string testAnswersString)
        {
            string[] elements = testAnswersString.Split(',');
            FirstName = elements[0];
            LastName = elements[1];
            int.TryParse(elements[2], out StudentId);
            Version = elements[3];
            int.TryParse(elements[4], out Score);
            Answers = elements.Skip(5).Take(elements.Length - 5).ToArray();
        }
    }
    
    public class Test
    {
        const string AnswerKeyName = "Answer Key";
        public TestAnswers AnswerKey;
        public TestAnswers[] StudentAnswers;
    
        public Test(string testCsvPath)
        {
            var allTestAnswers = File.ReadAllLines(testCsvPath).Skip(1).Select(answers => new TestAnswers(answers));
            AnswerKey = allTestAnswers.Single(answers => answers.FirstName == AnswerKeyName);
            StudentAnswers = allTestAnswers.Where(answers => answers.FirstName != AnswerKeyName).ToArray();
        }
    }
