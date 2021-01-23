    public void DoUpload(DriveInfo sel, IProgress<UploadStep> progress)
    {
        // Check that there is a device selected
        if (sel != null)
        {
            progress.Report(new UploadStep { Message = "First Task..." });
    
            // Generate List of images to upload
            var files = Directory.EnumerateFiles(sel.Name, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".png"));
    
            if (files.Count() > 0)
            {
                // Manage each image
                foreach (string item in files)
                {
                    // Generate thumbnail byte array
                    Thumbnails.Add(new ByteImage { Image = GenerateThumbnailBinary(item) });
                }
    
                progress.Report(new UploadStep { Message = "Generated Thumnails..." });
    
                foreach (string item in files)
                {
                    // Generate new name
                    Filenames.Add(
                        new NFile
                        {
                            OldName = Path.GetFileNameWithoutExtension(item),
                            NewName = Common.Security.KeyGenerator.GetUniqueKey(32)
                        });
                }
    
                progress.Report(new UploadStep { Message = "Uplaoding to database..." });
            }
        }
    }
