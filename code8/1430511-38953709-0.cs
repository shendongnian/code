    using (FileStream sourceStream = 
              new FileStream(file.FullName, FileMode.Open))
    {
        using (FileStream destStream = 
                    new FileStream(tempPath, FileMode.CreateNew))
        {
            while (true)
            {
                numReads++;
                int bytesRead = sourceStream.Read(buf, 0, buflen);
                if (bytesRead == 0) break; 
                destStream.Write(buf, 0, bytesRead);
                totalBytesRead += bytesRead;
                
                // TODO: Here you can track your progress
                // backgroundWorker1.ReportProgress((int)filepercent,"Files " + i + "/" + filecount + " " + Size + "/" + totalsize + " Mb");        
                
                if (bytesRead < buflen) break;
            }
        }
    }
