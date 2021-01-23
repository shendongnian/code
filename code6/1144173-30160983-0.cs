    public static class TeamSelectHeleper
    {
        public static double GetTotalByTeam(this List<ITotal> myList)
        {
            // TODO Sum wont work this way - fix it
            return myList.GroupBy(x => x.Team.Id).Sum(s => s.Total);
        }
    }
