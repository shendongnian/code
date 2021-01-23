    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace GetLabels
    {
        class Program
        {
            static void Main(string[] args)
            {
                string tfscollection = "http://xxx:8080/tfs/defaultcollection";
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(tfscollection));
                VersionControlServer vcs = ttpc.GetService<VersionControlServer>();
                string labelname = null;
                string labelscope = "$/";
                string owner = null;
                bool includeitem = false;
                int labelnumber;
                VersionControlLabel[] labels = vcs.QueryLabels(labelname,labelscope,owner,includeitem);
                labelnumber = labels.Length;
                Console.WriteLine(labelnumber);
                Console.ReadLine();
            }
        }
    }
