                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileCompleted += ((sender, args) =>
                    {
                        if (args.Error == null)
                        {
                            File.Move(filePath, Path.ChangeExtension(filePath, ".jpg"));
                            mr.Set();
                        }
                        else
                        {
                            //how to pass args.Error?
                        }
                    });
                    wc.DownloadFileTaskAsync(new Uri(string.Format("{0}/{1}", Settings1.Default.WebPhotosLocation, Path.GetFileName(f.FullName))), filePath).ContinueWith(t => t.Exception.Message)
                }
