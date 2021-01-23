        private bool CheckIfFileAlreadyExist(string WorkingDirectory, string FileToCopy)
        {
            string FileToCheck = File.ReadAllText(FileToCopy);
            foreach (string CurrentFile in Directory.GetFiles(WorkingDirectory))
            {
                if (File.ReadAllText(CurrentFile) == FileToCheck)
                    return true;
            }
            return false;
        }
