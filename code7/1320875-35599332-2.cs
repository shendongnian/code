    public bool IsValidFileSelection(string[] fileNames)
        {
            bool isValid = false;
            // There is no need to check the file types here.
            // As it is been restricted by the openFileBrowse
            if (fileNames != null && fileNames.Count() > 0)
            {
                if (fileNames.Count() == 1) // can be one .lfa file of one .log file
                {
                    isValid = true;
                }
                else
                {
                    // If multiple files are there. none shoulf be of type .lfa
                    isValid = ! fileNames.Any( f => Path.GetExtension(f) == IntegoConstants.Lfa_Extension);
                }
            }
            return isValid;
        }
