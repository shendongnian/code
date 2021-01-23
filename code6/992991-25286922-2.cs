    public static Task<bool> Empty(string targetDir)
    {
        return Task.Run(async () =>
        {
            foreach (var directory in Directory.GetDirectories(targetDir))
            {
                if (await Empty(directory))
                    Directory.Delete(directory, false);
            }
            var retval = true;
            foreach (string file in Directory.GetFiles(targetDir))
            {
                try
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
                catch(Exception ex)
                {
                    // something went wrong: log ex
                    retval = false;
                }
            }
            return retval;
        });
    }
