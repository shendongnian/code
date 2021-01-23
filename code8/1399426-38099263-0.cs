    public class StudyFieldService : IStudyFieldService{
        private readonly IDbSet<StudyField> _studyFields;
        public IDbContext DbCont { get; set; }
        public StudyFieldService()
        {
            _studyFields = DbCont.Set<StudyField>();
        }
    }
