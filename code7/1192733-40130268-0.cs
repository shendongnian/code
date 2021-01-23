    Process process = new Process()
                {
                    StartInfo = new ProcessStartInfo(path, "{Arguments If Needed}")
                    {
                        WindowStyle = ProcessWindowStyle.Normal,
                        WorkingDirectory = Path.GetDirectoryName(path)
                    }
                };
    
                process.Start();
