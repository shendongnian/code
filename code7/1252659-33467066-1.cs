    public float Efficiency
    {
       get
       {
           using(var db = new ScoresContext())
           {
               var allGoalsInSeason = db.Goals.Count();
               return (float)HisGoals.Count / allGoalsInSeason;
            }
        }
    }
