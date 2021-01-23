    select YEAR(ac.[Date]) as projectYear, MONTH(ac.[Date]) as projectMonth ,pr.ProjectNumber Info from Activities ac join Projects pr on ac.ProjectId=pr.ProjectId
    class ProjectActivity
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string ProjectNumber { get; set; }
        public static List<ProjectActivity> GetProjectActivities()
        {
            var sampleProjectActivities = new List<ProjectActivity>();
            var projActivitySamp1 = new ProjectActivity()
            {
                Year = 2014,
                Month = 1,
                ProjectNumber = "Contoso-2014-01"
            };
            sampleProjectActivities.Add(projActivitySamp1);
            var projActivitySamp2 = new ProjectActivity()
            {
                Year = 2014,
                Month = 3,
                ProjectNumber = "Contoso-2014-03"
            };
            sampleProjectActivities.Add(projActivitySamp2);
            var projActivitySamp3 = new ProjectActivity()
            {
                Year = 2016,
                Month = 4,
                ProjectNumber = "HP-2016-02"
            };
            sampleProjectActivities.Add(projActivitySamp3);
            var projActivitySamp4 = new ProjectActivity()
            {
                Year = 2016,
                Month = 4,
                ProjectNumber = "AnotherHP-2016-04"
            };
            sampleProjectActivities.Add(projActivitySamp4);
            return sampleProjectActivities;
        }
    }
           // Main Code
            var sampleProjectActivities = ProjectActivity.GetProjectActivities();
            var result = sampleProjectActivities.GroupBy(projectActivity => projectActivity.Year)
                .ToDictionary(k => k.Key,
                    v =>
                    {
                        return v.ToList()
                            .GroupBy(val => val.Month)
                            .ToDictionary(a => a.Key, b => b.ToList().Select(x => x.ProjectNumber).ToArray());
                    });
