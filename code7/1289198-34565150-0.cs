            public Manifest ReadServerNuspecFile(PackageRetrieveOptions options)
            {
                IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");
                var package = repo.FindPackage(options.ProjectName);
    
                using (var pkgStream = package.GetStream())
                {
                    var pkgReader = new PackageReader(pkgStream);
                    var manifest = Manifest.ReadFrom(pkgReader.GetNuspec(), true);
                    return manifest;
                }
            }
