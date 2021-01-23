    string txt = @"\LogFiles\W3SVC1\u_ex12.log:32:2014-08-02 05:50:37 &actor=%7B%22name%22%3A%5B%22Franklin%2C%20Francis%22%5D%2C%22mbox%22%3A%5B%22mailto%3AFranklin.Francis%40xyz.com%22%5D%7D&";
    
    var parts = txt.Split(' ');
    
    var urlParams = HttpUtility.UrlDecode(parts[2]);
    string actorJson = HttpUtility.ParseQueryString(urlParams).Get("actor");
    Actor actor = JsonConvert.DeserializeObject<Actor>(actorJson);
    
    Console.WriteLine(actor.Name + " " + actor.EmailAddress);
