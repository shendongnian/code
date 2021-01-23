    var questions = IZBSC.UI.Components.Utility.GetQuestionBank(Model.ExamId);
    var seed;
    if (Request.Cookies["Rnd"] == null)
    {
        seed = new Random().Next();
        HttpCookie cookie = new HttpCookie("Rnd", seed.ToString())
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddDays(1)
        };
        Response.Cookies.Add(cookie);
    }
    else
    {
        seed = int.Parse(Request.Cookies["Rnd"].Value);
    }
    var random = new Random(seed);
    @foreach (var question in questions.OrderBy(q =>random.Next()).Take(questions.Count).ToList())
    {...}
