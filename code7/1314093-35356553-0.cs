    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.TeamFoundation.Build.Client;
    using Microsoft.TeamFoundation.Client;
    
    namespace BuildAPI
    {
        class Program
        {
            static void Main(string[] args)
            {
                string project = "http://xxx.xxx.xxx.xxx";
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(project));
                IBuildServer ibs = tpc.GetService<IBuildServer>();
                var builds = ibs.QueryBuilds("TeamProjectName");
                foreach (IBuildDetail ibd in builds)
                {
                    Console.WriteLine(ibd.DropLocation);
                    Console.ReadLine();
                }
            }
        }
    }
