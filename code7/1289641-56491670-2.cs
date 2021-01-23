     foreach (DataRow r in rstDatabase.ReadFileList(sqlServer).Rows)
                    {
                        var relocateFile = new RelocateFile();
                        relocateFile.LogicalFileName = r["LogicalName"].ToString();
                        Console.WriteLine(relocateFile.LogicalFileName);
                        var physicalName = r["PhysicalName"].ToString();
                        Console.WriteLine(physicalName);
                        var path = System.IO.Path.GetDirectoryName(physicalName);
                        Console.WriteLine(path);
                        var filename = System.IO.Path.GetFileName(physicalName);
                        Console.WriteLine(filename);
                        physicalName = path + @"\H5MI_Automation_Restore_Backup_" + filename;
                        Console.WriteLine(physicalName);
                        relocateFile.PhysicalFileName = physicalName;
                        Console.WriteLine(relocateFile.PhysicalFileName);
                        Console.WriteLine(relocateFile);
                        rstDatabase.RelocateFiles.Add(relocateFile);
                    }
