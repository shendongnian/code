    public class SecurityQuestions
    {
        public int Question1Id { get; set; }
        public int Question2Id { get; set; }
        public int Question3Id { get; set; }
        public int Question4Id { get; set; }
        public int Question5Id { get; set; }
        public int Question6Id { get; set; }
        [UniqueAnswersOnly]
        public string Answer1 { get; set; }
        [UniqueAnswersOnly]
        public string Answer2 { get; set; }
        [UniqueAnswersOnly]
        public string Answer3 { get; set; }
        [UniqueAnswersOnly]
        public string Answer4 { get; set; }
        [UniqueAnswersOnly]
        public string Answer5 { get; set; }
        [UniqueAnswersOnly]
        public string Answer6 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var questions = new SecurityQuestions();
            questions.Answer1 = "Test";
            questions.Answer2 = "Test";
            questions.Answer3 = "Test3";
            questions.Answer4 = "Test4";
            questions.Answer5 = "Test5";
            questions.Answer6 = "Test6";
            var vc = new ValidationContext(questions, null, null);
            var results = new List<ValidationResult>();
            var validationResult = Validator.TryValidateObject(questions, vc, results, true);
        }
    }
