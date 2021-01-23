    private bool RecursiveRemove(folder thisList, folder thefolder)
    {
        if (thisList.Contains(theFolder))
        {
            thisList.Remove(theFolder);
            return true;
        }
        else
        {
            foreach (var folder in thisList.subFolders)
            {
                if (RecursiveRemove(folder, theFolder))
                {
                    return true;
                }
            }
        }
        return false;  // not found
    }
