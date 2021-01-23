     IEnumerable<Change> changes = vcs.GetChangesForChangeset(12345, false, Int32.MaxValue, null, null, true);
        foreach (Change change in changes)
        {
            foreach (var m in change.MergeSources)
            {
                //m.VersionFrom;
                //m.VersionTo;
            }
        }
