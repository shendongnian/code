    try
    {
       // Run the program again
       Process.Start(Application.ResourceAssembly.Location);
       // Close the Old one
       Process.GetCurrentProcess().Kill();
    }
    catch
    { }
