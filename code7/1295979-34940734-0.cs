    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Server;
    
    namespace AAAPI
    {
        class Program
        {
            static void Main(string[] args)
            {
                string project = "https://xxx.xxx.xxx.xxx/tfs";
                string projectName = "XXX";
                string node1 = "Year";
                string node2 = "Iter1";
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(project));
                tpc.Authenticate();
                Console.WriteLine("Creating node" + node1);
                var css = tpc.GetService<ICommonStructureService>();
                string rootNodePath = string.Format("\\{0}\\Iteration", projectName);
                var pt = css.GetNodeFromPath(rootNodePath);
                css.CreateNode(node1, pt.Uri);
                Console.WriteLine("Creating" + node1 + "Successfully");
                Console.WriteLine("Creating node" + node2);
                string parentNodePath = string.Format("\\{0}\\Iteration\\{1}", projectName, node1);
                var pt1 = css.GetNodeFromPath(parentNodePath);
                css.CreateNode(node2, pt1.Uri);
                Console.WriteLine("Creating" + node2 + "Successfully");
                Console.ReadLine();
            }
        }
    }
