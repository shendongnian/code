    public class BasePage : System.Web.UI.Page
    {
                 public static ProjectDTO Project 
                 { 
                    get {return (ProjectDTO)HttpContext.Current.Session["Project"];}
                 }
                 // some other code
        
                 // Passing the Project to the Master.
                 public void SetProject()
                 {
                   SiteMaster masterPage = Master as SiteMaster;
                   masterPage.Project = Project;
                 }
    }
