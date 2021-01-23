    public partial class School
    {
        [NotMapped]
        public string SchoolState {get; set;}
        [NotMapped]
        public List<string> SchoolRankings;
        void AddSchoolRanking()
        {
             ...
        }
    }
