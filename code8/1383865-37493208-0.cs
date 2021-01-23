    public class UserData
    {
         public string UserName;
         public string Pass;
         public string CurTemplate;
    }
    private IEnumerable<UserData> GetUserData(XElement xmlDoc)
    {
        return
              xmlDoc.Descendants("UserData").Select(u => new UserData
              {
                  UserName = u.Element("UserName").Value,
                  Pass = u.Element("Pass").Value,
                  CurTemplate = u.Element("CurrentTemplate").Value
              });
    }
