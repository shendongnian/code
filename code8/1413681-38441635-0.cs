    public void FindDirectoriesWithFiles(List<string> paths, DirectoryInfo workingDir)
    {
        // if this directory has files in it, add its path to the list.
        if (workingDir.GetFiles().Length > 0)
        {
            paths.Add(workingDir.FullName);
        }
        else
        {
            // Else, this directory has no files, so iterate through its children.
            foreach (var childDir in workingDir.GetDirectories())
            {
                FindDirectoriesWithFiles(paths, childDir);
            }
        }
    }
