    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Discussion.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace LightweightCodeView
    {
        class Program
        {
            static void Main(string[] args)
            {
                string projecturi = "https://xxx:8080/tfs/";
                int changesetid = xxx;
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(projecturi));
                VersionControlServer vcs = ttpc.GetService<VersionControlServer>();
                Changeset cset = vcs.GetChangeset(changesetid);
                TeamFoundationDiscussionService tfds = new TeamFoundationDiscussionService();
                tfds.Initialize(ttpc);
                IDiscussionManager idm = tfds.CreateDiscussionManager();
                IAsyncResult iar = idm.BeginQueryByVersion(cset.ArtifactUri, QueryStoreOptions.ServerOnly, new AsyncCallback(Callback), null);
                var threads = idm.EndQueryByVersion(iar);
                foreach (DiscussionThread dt in threads)
                {
                    Console.WriteLine(dt.RootComment.Content);
                    Console.WriteLine(dt.RootComment.Author.DisplayName);
                    Console.ReadLine();
                }
            //Update Changeset comments
            cset.Comment = "New Comments";
            cset.Update();
            }
            static void Callback(IAsyncResult result)
            {
            }
        }
    }
