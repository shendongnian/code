    ProcessStartInfo createProject = new ProcessStartInfo();
    createProject.FileName = exePath;
    createProject.UseShellExecute = false;
    createProject.WorkingDirectory = projectDirectory;
    createProject.Arguments = exeArguments;
    
    try
    {
        using (System.Diagnostics.Process exeProcess = System.Diagnostics.Process.Start(createProject ))
              {
                 exeProcess.WaitForExit();
              }
    }
    catch (IOException eX)
    {
        // Log error.
        MessageBox.Show("Unable to create project", "Error Creating Project");
    
    }
