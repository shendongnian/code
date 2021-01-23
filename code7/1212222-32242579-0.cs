     foreach (IndexFile file in indexManager.fileList)
                {
                    this.Dispatcher.Invoke((Action)(() =>
                        {
                            tabList.Add(new FileTab(file.filePath));
                            Console.WriteLine("-(DoWork)->" + i);
                            double percentage = (Convert.ToDouble(i) / Convert.ToDouble(indexManager.fileList.Count)) * 100;
                            Console.WriteLine("-(DoWork.percentage)-> "+ percentage);
                            backgroundWorker.ReportProgress((int)percentage);
                        }));
                    i++;
                   
                }
