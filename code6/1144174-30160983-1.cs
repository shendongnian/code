    public static class TeamSelectHeleper
    {
        public static double GetTotalByTeam(this List<ITotal> myList)
        {
            // TODO Sum wont work this way - fix it
            //return myList.GroupBy(x => x.Team.Id).Sum(s => s.Total);
            // If you need just a sum, then just sum it.
            // but if you need group results,
            // then you can just return on number when there is a list
            return myList.Sum(s => s.Total);
        }
    }
