    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace TFSAPI
    {
        class Program
        {
            static void Main(string[] args)
            {
                string project = "http://xxxxx:8080/tfs/DefaultCollection";
                NetworkCredential nc = new NetworkCredential("username","pwd");
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(project), nc);
                tpc.Authenticate();
                VersionControlServer vcs = tpc.GetService<VersionControlServer>();
                int cid = vcs.GetLatestChangesetId();
                string p = "$/ProjectName";
                var h = vcs.QueryHistory(p,RecursionType.Full,5);
                Console.WriteLine("Following are the latest 5 changeset in " + p +":");
                foreach (Changeset item in h)
                {
                    Console.WriteLine("{0} {1}", item.ChangesetId, item.Comment);
                }
                Console.WriteLine("The latest changeset ID is:" + cid);
                Console.ReadLine();
            }
        }
    }
