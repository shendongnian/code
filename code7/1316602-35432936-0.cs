    private IEnumerable<Player> ReadPlayers(TextReader rd){
      string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split(';');
                string name = s[0];
                int score = int.Parse(s[1]);
                yield return new Player(name, score);
            }
    }
    private void Scores_Load(object sender, EventArgs e)
    {
        string filename = "highscores.txt";
        using (StreamReader sr = File.OpenText(filename)){ 
          var sortedPlayers= ReadPlayers(rd)
                                 .OrderByDescending(x=x.Score)
                                 .Take(10)
                                 .Select((p,r)=>$"rank {r+1}:{p.Name} : {p.Score}");
           lstScore.Items.Clear();
           foreach(var p in sortedPlayers) lstScore.Items.Add(p); 
        }
