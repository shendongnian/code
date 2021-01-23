    class QuizModel
    {
        public string HowMuchDoYouLikeCSharp {get;set;}
        public string HowMuchDoYouLikeCPlusPlus {get;set;}
    }
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string QuestionModelProp {get;set;} //This must match a prop name in the QuizModel
        public List<string> PossibleAnswers { get; set; }
        public string generateHTML()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append("<div>"+Question+"</div>");
            foreach (string answer in PossibleAnswers)
            {
                ret.Append(String.Format(@"<input name='{0}' type='radio' value='{1}'/>{1}<br/>", QuestionModelProp, answer));
            }
            return ret.ToString();
        }
    }
    [HttpPost]
    public ActionResult SubmitAction(QuizModel quizData)
    {      
        string HowMuchDoYouLikeCSharp = quizData.HowMuchDoYouLikeCSharp;
        string HowMuchDoYouLikeCPlusPlus = quizData.HowMuchDoYouLikeCPlusPlus;
    }
