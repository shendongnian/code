            var context = new DirectoryContext(DirectoryContextType.Domain, "domain");
            using (var domainController = DomainController.FindOne(context))
            {
                using (var directorySearcher = domainController.GetDirectorySearcher())
                {
                    directorySearcher.Filter = String.Format("(sAMAccountName={0})", "login");
                    directorySearcher.SizeLimit = 1;
                    var userDirectory = directorySearcher.FindOne();
                    using (var userDirectoryEntry = userDirectory.GetDirectoryEntry())
                    {
                        var active = userDirectoryEntry.IsActive();
                    }
                }
            }
