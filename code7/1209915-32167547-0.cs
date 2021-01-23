    Stream st = await new WebClient().OpenReadTaskAsync(Link);
    
     using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream file = new IsolatedStorageFileStream(FileName, FileMode.OpenOrCreate, isf))
                    {
                        using (var fs = new StreamWriter(file))
                        {
                            byte[] bytesInStream = new byte[st.Length];
                            st.Read(bytesInStream, 0, (int)bytesInStream.Length);
                            file.Write(bytesInStream, 0, bytesInStream.Length);
                            file.Flush();
                        }
                    }
                }
            }
    
    
    SaveRingtoneTask task = new SaveRingtoneTask();
    task.Source = new Uri(string.Format("isostore:/{0}"selected.FileName),UriKind.Absolute);                    
    task.Completed += task_Completed;
    task.Show();
