     for (int i = 0; i < allVendorIDs.Length; i++)
                    {
                        int j = i;
                        Task task = new Task(() => FTPMode(allVendorIDs[j]));
                        vendorWiseTasksListening.Add(task);
                        task.Start();
                        task = new Task(() => SharedMode(allVendorIDs[j]));
                        vendorWiseTasksListening.Add(task);
                        task.Start();
                    }
 
