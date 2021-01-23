    using(var repo = new Repository("c:\\_Temp\\Repo"))
    {
     List<string> shalist = new List<string>();
     foreach(Commit c in repo.Commits)
     {
      DateTime since = DateTime.Parse("10/29/2015 12:00:00 AM");
      DateTime untill= c.Author.When.Date;
    
      if(untill >= since)
       {
         shalist.Add(c.sha.Tostring());
       }
      }
      Tree cmTree1 = repo.Lookup<Commit>(shalist.First()).Tree;  
      Tree cmTree2 = repo.Lookup<Commit>(shalist.Last()).Tree;
      var patch = repo.Diff.Compare<patch>(cmTree1, cmTree2);
      foreach(var ptc in patch)
      {
       Console.WriteLine(ptc.Path);
      }     
    }
