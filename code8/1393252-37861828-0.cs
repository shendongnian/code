    public static class ThirdPartyHelpers
      {
        private static readonly ThirdParty.Dao dao = new ThirdParty.Dao();
    
        public static ThirdParty.User GetUser()
        {
          return dao.GetUser();
        }
    
        public static ThirdParty.Team GetTeam()
        {
          return dao.GetTeam();
        }
    
        public static User Decoupled(this ThirdParty.User user)
        {
          var myUser = new User();
          myUser.Id = user.Id;
          myUser.Name = user.FirstName + " " + user.LastName;
    
          return myUser;
        }
    
        public static ThirdParty.User ToThirdParty(this User user)
        {
          var thierUser = dao.GetUser(user.Id);
          return thierUser;
        }
    
        public static Team Decoupled(this ThirdParty.Team team)
        {
          var myTeam = new Team();
          myTeam.Id = team.Id;
          myTeam.Name = team.Name;
    
          return myTeam;
        }
    
        public static ThirdParty.Team ToThirdParty(this Team team)
        {
          var theirTeam = dao.GetTeam(team.Id);
          return theirTeam;
        }
      }
      
