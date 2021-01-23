    string json2 = File.ReadAllText(@"C:\Temp\Assess.json");
    var root = new System.Web.Script.Serialization.JavaScriptSerialize().Deserialize<List<WebApplication1.Models.SchoolSubject>>(json2);
    
    var seasons = new List<string>();
    var years = new List<string>();
    
        foreach (var subject in root)
        {
            <h2>@Html.Raw(subject.Subject)</h2>
            foreach (var item in subject.AppScores)
            {
                <p>@Html.Raw(item.Season)</p> 
                <p>@Html.Raw(item.year)</p>
    
                seasons.Add(item.Season);
                years.Add(item.year);
                }
            }
