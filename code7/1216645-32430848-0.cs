    using System;
    using System.Security;
    using Microsoft.ProjectServer.Client;
    using Microsoft.SharePoint.Client;
    
    public class Program
    {
        private const string pwaPath = "https://[yoursitehere].sharepoint.com/sites/pwa";
        private const string username ="[username]";
        private const string password = "[password]";
        static void Main(string[] args)
        {
            SecureString secpassword = new SecureString();
            foreach (char c in password.ToCharArray()) secpassword.AppendChar(c);
    
    
            ProjectContext pc = new ProjectContext(pwaPath);
            pc.Credentials = new SharePointOnlineCredentials(username, secpassword);
            
            //now you can query
            pc.Load(pc.Projects);
            pc.ExecuteQuery();
            foreach(var p in pc.Projects)
            {
                Console.WriteLine(p.Name);
            }
    
            //Or Create a new project
            ProjectCreationInformation newProj = new ProjectCreationInformation() {
                Id = Guid.NewGuid(),
                Name = "[your project name]",
                Start = DateTime.Today.Date
            };        
            PublishedProject newPublishedProj = pc.Projects.Add(newProj);
            QueueJob qJob = pc.Projects.Update();
    
            JobState jobState = pc.WaitForQueue(qJob,/*timeout for wait*/ 10);
            
        }
    
    }
