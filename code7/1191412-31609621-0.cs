    public class ProjectData
    {
            public static string Username {get;set;}
    }
    public class ViewModel {
       public string UserName {
          get{ return ProjectData.Username ; }
          set { ProjectData.Username  = value; }
       }
    }
