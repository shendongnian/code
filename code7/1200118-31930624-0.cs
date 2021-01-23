    var excludedFiles = new List<string>{"Settings.settings", "packages.config"};
    var artifactDir = "./Artifact";
    var solutionFile = "./MySolution.sln";
    
    Task("Package")
        .IsDependentOn("Build")
        .Does(() =>
        {
            var solution = ParseSolution(solutionFile);
            foreach (var project in solution.Projects)
            {
                var parsedProject = ParseProject(project.Path);
                var binDir = project.Path.GetDirectory() + Directory("/bin");
                
                if(project.Name.Contains("Host"))
                {             
                    var soaDir = Directory(artifactDir + "/SOA");
                    CreateDirectory(soaDir);
                    CopyDirectory(binDir, soaDir + Directory("bin"));
                    foreach(var file in parsedProject.Files)
                    {
                        if(!file.Compile && excludedFiles.All(x=> !file.FilePath.ToString().Contains(x)))
                        {                        
                            var newFilePath = soaDir + File(file.RelativePath);
                            CreateDirectory(((FilePath)newFilePath).GetDirectory());
                            CopyFile(file.FilePath, newFilePath);
                        }
                    }
                }
            }        
        });
