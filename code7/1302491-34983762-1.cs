    @{
        ViewBag.Title = "SchoolSubject";
    }
    
    <h2>SchoolSubject</h2>
    
    @{ 
        string json = File.ReadAllText("JSON.json");
        var root = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<SchoolSubject>>(json);
        foreach (var subject in root)
        {
            @Html.Raw(subject.Subject);
    
            foreach (var item in subject.AppScores)
            {
                @Html.Raw(item.Season);
                @Html.Raw(item.year);
            }
        }
    
    }
    
    @{
        public class SchoolSubjectAppScore
        {
            public string Season { get; set; }
            public string year { get; set; }
        }
    
        public class SchoolSubject
        {
            public SchoolSubject() { this.AppScores = new List<SchoolSubjectAppScore>(); }
            public string Subject { get; set; }
            public List<SchoolSubjectAppScore> AppScores { get; set; }
        }
    }
