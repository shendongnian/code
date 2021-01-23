    // Using the PowerShell object, call the Create() method 
    // to create an empty pipeline, and then call the methods  
    // needed to add the commands to the pipeline. Commands 
    // parameters, and arguments are added in the order that the 
    // methods are called.
    PowerShell ps = PowerShell.Create();
    ps.AddCommand("Get-Process");
    ps.AddArgument("wmi*");
    ps.AddCommand("Sort-Object");
    ps.AddParameter("descending");
    ps.AddArgument("id");
    Console.WriteLine("Process               Id");
    Console.WriteLine("------------------------");
    // Call the Invoke() method to run the commands of 
    // the pipeline synchronously.
    foreach (PSObject result in ps.Invoke())
    {
      Console.WriteLine("{0,-20}{1}",
              result.Members["ProcessName"].Value,
              result.Members["Id"].Value);
    } // End foreach.
