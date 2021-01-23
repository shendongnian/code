    // Create a new process
    ProcessStartInfo process = new ProcessStartInfo();
    // set name of process to "WMIC.exe"
    process.FileName = "WMIC.exe";
    // pass rename PC command as argument
    process.Arguments = "computersystem where caption='" + System.Environment.MachineName + "' rename " + newName;
    // Run the external process & wait for it to finish
    using (Process proc = Process.Start(process))
    {
        proc.WaitForExit();
        // print the status of command
        Console.WriteLine("Exit code = " + proc.ExitCode);
    }
}
