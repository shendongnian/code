    @{
        ViewBag.Title = "SchoolSubject";
    }
    
    <h2>SchoolSubject</h2>
    
    @{ 
        string json = File.ReadAllText("JSON.json");
        var root = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<MyTest.Models.SchoolSubject>>(json);
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
    
