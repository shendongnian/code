    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Server;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using Microsoft.TeamFoundation.Framework.Client;
    
    namespace API
    {
        class Program
        {
            static void Main(string[] args)
            {
                string project = "http://xxx.xxx.xxx.xxx:8080/tfs";
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(project));
                var tps = tpc.GetService<VersionControlServer>();
                var ttt = tps.GetTeamProject("ProjectName");
                ISecurityService securityService = tpc.GetService<ISecurityService>();
                System.Collections.ObjectModel.ReadOnlyCollection<SecurityNamespace> securityNamespaces = securityService.GetSecurityNamespaces();
                IGroupSecurityService gss = tpc.GetService<IGroupSecurityService>();
                Identity SIDS = gss.ReadIdentity(SearchFactor.AccountName, "GroupName", QueryMembership.Expanded);//GourName format: [ProjectName]\\GourpName
                IdentityDescriptor id = new IdentityDescriptor("Microsoft.TeamFoundation.Identity", SIDS.Sid);
                List<SecurityNamespace> securityList = securityNamespaces.ToList<SecurityNamespace>();
                string securityToken;
                foreach (SecurityNamespace sn in securityList)
                {
                    if (sn.Description.DisplayName == "Project")
                    {
                        securityToken = "$PROJECT:" + ttt.ArtifactUri.AbsoluteUri;
                        sn.SetPermissions(securityToken, id, 115, 0, true);
                    }
                }                
            }
        }
    }
