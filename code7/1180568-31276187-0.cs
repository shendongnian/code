    public class SecurityQuestions : IValidatableObject
    {
        public int Question1Id { get; set; }
    
        public int Question2Id { get; set; }
    
        public int Question3Id { get; set; }
    
        public int Question4Id { get; set; }
    
        public int Question5Id { get; set; }
    
        public int Question6Id { get; set; }
    
        public string Answer1 { get; set; }
    
        public string Answer2 { get; set; }
    
        public string Answer3 { get; set; }
    
        public string Answer4 { get; set; }
    
        public string Answer5 { get; set; }
    
        public string Answer6 { get; set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var securityAnswers = new List<string>();
            securityAnswers.Add(this.Answer1);
            securityAnswers.Add(this.Answer2);
            securityAnswers.Add(this.Answer3);
            securityAnswers.Add(this.Answer4);
            securityAnswers.Add(this.Answer5);
            securityAnswers.Add(this.Answer6);
    
            bool hasDuplicates = securityAnswers.GroupBy(x => x).Where(g => g.Count() > 1).Any();
    
            if (hasDuplicates)
            {
                yield return new ValidationResult(
                    "There are duplicate Answers...");
            }
        }
    }
