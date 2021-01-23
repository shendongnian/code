    internal class QuestionMap: ClassMap<Question>
    {
        public QuestionMap()
        {
            ReadOnly();
            Table("Question");
            Id(x => x.Id).Column("Id").GeneratedBy.Assigned();
            Map(x => x.Text);
            References(x => x.LanguageCode).Column("LanguageCode");
        }
    }
