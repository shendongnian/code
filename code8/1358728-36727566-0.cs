    //define a class to store your scores
    public class Score
    {
        public string Username { get; set; }
        public decimal Score { get; set; }
     
        public Score()
        {
    
        }
    }
    //then reading the values
    var scores = new List<Score>();
    string line = "";
    while ((line = sr.ReadLine()) != null)
    {
        var lineArray = line.Split(';');
        scores.Add(new Score{ Username = line[0], Score = line[1] });
    }
    // then sort the list using linq
    scores = scores.OrderByDescending(x => x.Score).ToList();
