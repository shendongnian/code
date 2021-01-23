            string isoPath = "C:\\Path\\To\\Image.iso";
            using (var ps = PowerShell.Create())
            {
                
                //Mount ISO Image
                var command = ps.AddCommand("Mount-DiskImage");
                command.AddParameter("ImagePath", isoPath);
                command.Invoke();
                ps.Commands.Clear();
                //Get Drive Letter ISO Image Was Mounted To
                var runSpace = ps.Runspace;
                var pipeLine = runSpace.CreatePipeline();
                var getImageCommand = new Command("Get-DiskImage");
                getImageCommand.Parameters.Add("ImagePath", isoPath);
                pipeLine.Commands.Add(getImageCommand);
                pipeLine.Commands.Add("Get-Volume");
                string driveLetter = null;
                foreach (PSObject psObject in pipeLine.Invoke())
                {
                    driveLetter = psObject.Members["DriveLetter"].Value.ToString();
                    Console.WriteLine("Mounted On Drive: " + driveLetter);
                }
                pipeLine.Commands.Clear();
                //Unmount Via Image File Path
                command = ps.AddCommand("Dismount-DiskImage");
                command.AddParameter("ImagePath", isoPath);
                ps.Invoke();
                ps.Commands.Clear();
                //Alternate Unmount Via Drive Letter
                ps.AddScript("$ShellApplication = New-Object -ComObject Shell.Application;" + 
                    "$ShellApplication.Namespace(17).ParseName(\"" + driveLetter + ":\").InvokeVerb(\"Eject\")");
                ps.Invoke();
                ps.Commands.Clear();
            }
