    public class ProjectOverview
    {
       public int Id { get; set; }
       public int Name { get; set; }
    }
    public List<ProjectOverview> GiveMeProjects(int id)
            {
                Entities.VSTMEntities vstm = new Entities.VSTMEntities();
                var currentUserProject = (from users in vstm.Users
                                          from project in users.Projects
                                          where users.UserID == id
                                          select new ProjectOverview()
                                          {
                                              Id = project.ProjectID,
                                              Name = project.ProjectName
                                          }).ToList();
    
                return currentUserProject;
            }
