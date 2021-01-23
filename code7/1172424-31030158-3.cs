        private bool CheckIfFileAlreadyExist(string WorkingDirectory, string FileToCopy)
        {
            byte[] FileToCheck = File.ReadAllBytes(FileToCopy);
            foreach (string CurrentFile in Directory.GetFiles(WorkingDirectory))
            {
                if (File.ReadAllBytes(CurrentFile) == FileToCheck)
                    return true;
            }
            return false;
        }
