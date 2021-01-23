                Forest adForest = Forest.GetCurrentForest();
                ActiveDirectorySite[] sites = new ActiveDirectorySite[adForest.Sites.Count];
                adForest.Sites.CopyTo(sites, 0);
                List<ActiveDirectorySubnet> subnets = new List<ActiveDirectorySubnet>();
                sites.ToList().ForEach(x =>
                {
                    ActiveDirectorySubnet[] subnetTemp = new ActiveDirectorySubnet[x.Subnets.Count];
                    x.Subnets.CopyTo(subnetTemp, 0);
                    subnets.AddRange(subnetTemp);
                });
                IPAddress address = IPAddress.Parse("IPAddress to look up closest DC");
                var currentSubnet = subnets.Where(x => address.IsInRange(x.Name));
                var location = currentSubnet.First().Site.Name;
    
                DomainController dc = DomainController.FindOne(new DirectoryContext(DirectoryContextType.Domain, Domain), location);
