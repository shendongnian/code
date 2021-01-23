    using System; 
    using Microsoft.TeamFoundation.Client; 
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace API {
        class Program
        {
            static void Main(string[] args)
            {
                string vsuri = "http://xxx.xxx.xxx.xxx";
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(vsuri));
                tpc.EnsureAuthenticated();
                VersionControlServer vcs = tpc.GetService<VersionControlServer>();
                Workspace ws = vcs.CreateWorkspace("NewWorkSpace");
                ws.Map("$/ProjectName","C:\\LocationPath");
                int changesetversiontoget = 111;
                ChangesetVersionSpec cvs = new ChangesetVersionSpec(changesetversiontoget);
                ws.Get(cvs,GetOptions.GetAll);
            }
        } }
