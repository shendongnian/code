            //see https://stackoverflow.com/questions/19581094/programmatically-copy-files-from-temporary-internet-files-into-other-directory
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache), "Content.IE5");
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);   
            HashSet<string> extensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            extensions.Add(".ico");
            extensions.Add(".jpg");
            extensions.Add(".jpeg");
            extensions.Add(".png");
            extensions.Add(".gif");
            extensions.Add(".bmp");
   
            string DestinationFolder2Copyfiles = @"e:\images\";
            HashSet<string> alreadyCopiedFilesHolder = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string f in files)
            {
                string ext = System.IO.Path.GetExtension(f);
                if (extensions.Contains(ext))
                {
                    string destFileName = Path.Combine(DestinationFolder2Copyfiles, Path.GetFileName(f));
                    int i = 0;
                    while (alreadyCopiedFilesHolder.Contains(destFileName) || System.IO.File.Exists(destFileName))
                    {
                        destFileName = Path.Combine(DestinationFolder2Copyfiles, string.Format("{0}_{1}{2}", Path.GetFileNameWithoutExtension(f), i, ext));
                        i += 1;
                    }
                    alreadyCopiedFilesHolder.Add(destFileName);
                    System.IO.File.Copy(f, destFileName);
                }
            }
