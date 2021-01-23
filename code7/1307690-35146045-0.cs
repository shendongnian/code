                    if (files.Length != 0)
                    {
                        List<Task> tasks = new List<Task>();
                        foreach (var file in files)
                        {
                            var task = Task.Factory.StartNew(() =>
                                                        {
                                                            bool taskResult = ReadFile(file);
                                                            return taskResult;
                                                        });
                            tasks.Add(task);
    
                        }
                        Task.WaitAll(tasks.ToArray());
                        // Message here
                        DialogResult result2 = MessageBox.Show("Read the files successfully.", "Important message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
