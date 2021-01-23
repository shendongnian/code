    public enum QuestionTypeEnum
    {
        Closed = 0,
        Open = 1
    }
    
    public class QuestionType : EnumTable<QuestionTypeEnum>
    {
        public QuestionType(QuestionTypeEnum enumType) : base(enumType)
        {
        }
    
        public QuestionType() : base() { } // should excplicitly define for EF!
    }
