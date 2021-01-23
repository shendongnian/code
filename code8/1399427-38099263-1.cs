    public class StudyFieldService : IStudyFieldService{
        private readonly IDbSet<StudyField> _studyFields;
        public IDbContext Context{ get; set; }
        public StudyFieldService()
        {
            _studyFields = Context.Set<StudyField>();
        }
    }
