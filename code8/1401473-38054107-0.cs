     private void button1_Click(object sender, EventArgs e)
        {
            int deletedFilesCount = 0;
            int nonDeleted=0;
            foreach(object obj in checkedListBox1.CheckedItems )
            {
               
                if (!obj.ToString().Equals("Select All"))
                {
                    try
                    {
                         System.IO.File.Delete(obj.ToString());
                         deletedFilesCount++;
                    }
                    catch(Exception)
                    {
                        UnDeletableFiles.Add(obj.ToString()); string error = string.Format("File cannot be deleted, it is currently open : {0}", obj.ToString()); 
                        WriteLogMessage(LogFileName, "");
                        WriteLogMessage(LogFileName, error);
                        nonDeleted++;
                    }
                   
                }
               
            }
            //your log
           // deletedFilesCount:
            //nonDeleted
        }
