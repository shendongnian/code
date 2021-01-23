    public class WebinarQuestions 
    {
       public WebinarQuestions(IEnumerable<WebinarQuestion> questions)
       {
           Questions = questions.OrderBy(x => x).ToList();
       }
       public IReadOnlyList<WebinarQuestion> Questions { get; private set; }
       
       public static WebinarQuestions FromJson(string json)
       {
           var questions = JsonConvert.DeserializeObject<List<WebinarQuestion>>(json);
           return new WebinarQuestions(questions);
       }
    }
