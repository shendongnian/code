        static internal string[] GetProjectFilesInSolution()
        {
            IVsSolution sol = ServiceProvider.GlobalProvider.GetService(typeof(SVsSolution)) as IVsSolution;
            uint numProjects;
            ErrorHandler.ThrowOnFailure(sol.GetProjectFilesInSolution((uint)__VSGETPROJFILESFLAGS.GPFF_SKIPUNLOADEDPROJECTS, 0, null, out numProjects));
            string[] projects = new string[numProjects];
            ErrorHandler.ThrowOnFailure(sol.GetProjectFilesInSolution((uint)__VSGETPROJFILESFLAGS.GPFF_SKIPUNLOADEDPROJECTS, numProjects, projects, out numProjects));
            //GetProjectFilesInSolution also returns solution folders, so we want to do some filtering
            //things that don't exist on disk certainly can't be project files
            return projects.Where(p => !string.IsNullOrEmpty(p) && System.IO.File.Exists(p)).ToArray();
        }
