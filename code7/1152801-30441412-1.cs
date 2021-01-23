    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // the path of the source file
            string sourceFile = @"\\shared\test.txt";
            // the path to write the file to
            string destFile = @"\\shared2\test2.txt";
            FileInfo info = new FileInfo(sourceFile);
            // gets the size of the file in bytes
            Int64 size = info.Length;
            // keeps track of the total bytes downloaded so you can update the progress bar
            Int64 runningByteTotal = 0;
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            {
                using (Stream writer = new FileStream(destFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    int iByteSize = 0;
                    byte[] byteBuffer = new byte[size];
                    while ((iByteSize = reader.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                    {
                        // write the bytes to the file
                        writer.Write(byteBuffer, 0, iByteSize);
                        runningByteTotal += iByteSize;
                        // calculate the progress
                        double index = (double)(runningByteTotal);
                        double total = (double)byteBuffer.Length;
                        double progressPercentage = (index / total);
                        int iProgressPercentage = (int)(progressPercentage * 100);
                        // update the progress bar
                        backgroundWorker1.ReportProgress(iProgressPercentage);
                    }
                    // clean up the file stream
                    writer.Close();
                }
            }
        }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
