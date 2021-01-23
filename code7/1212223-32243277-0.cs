    void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                int i = 0;
                foreach (IndexFile file in indexManager.fileList)
                {
                    i++;
                    Console.WriteLine("-(DoWork)->" + i);
                    double percentage = (Convert.ToDouble(i) / Convert.ToDouble(indexManager.fileList.Count)) * 100;
                    Console.WriteLine("-(DoWork.percentage)-> "+ percentage);
                    backgroundWorker.ReportProgress((int)percentage,new FileTab(file.filePath));
                }
            }
