    public bool? HasLeaderOtherThanSelf
    {
       if(LeaderMembership == null)
       {
          return null;
       }
       return LeaderMembership.AthleteId != App.CurrentAthlete.Id;
    }
