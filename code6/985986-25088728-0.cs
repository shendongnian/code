    private void SaveAllFiles()
        {
            for (int i = 1; i <= soln.Projects.Count; i++)
            {
                if (!soln.Projects.Item(i).Saved)
                {
                    soln.Projects.Item(i).Save();
                }
                for (int j = 1; i <= soln.Projects.Item(i).ProjectItems.Count; i++)
                {
                    if (!soln.Projects.Item(i).ProjectItems.Item(j).Saved)
                    {
                        soln.Projects.Item(i).ProjectItems.Item(j).Save();
                    }
                }
            }
        }
