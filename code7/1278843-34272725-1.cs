    private static bool processDirectory(string startLocation)
    {
        bool result = true;
        foreach (var directory in Directory.GetDirectories(startLocation))
        {
            bool directoryResult = processDirectory(directory);
            result &= directoryResult;
            if (Directory.GetFiles(directory, "*.dvr").Any())
            {
                 result = false;
                 continue;
            }
            foreach(var file in Directory.GetFiles(directory))
            {
                try
                {
                   File.Delete(file);
                }
                catch(IOException)
                {
                   // error handling
                   result = directoryResult = false;
                }
            }
            if (!directoryResult) continue;
            try
            {
                Directory.Delete(directory, false);
            }
            catch(IOException)
            {
                // error handling
                result = false;
            }
        }
        return result;
    }
