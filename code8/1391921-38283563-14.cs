    string SortAndCombine()
    {
        long processed; // keep track of how much we processed
        do
        {
            // iterate the folder
            var files = Directory.EnumerateFiles(sortdir).GetEnumerator();
            bool hasnext = files.MoveNext();
            processed = 0;
            while (hasnext)
            {
                processed++;
                // have one
                string fileOne = files.Current;
                hasnext = files.MoveNext();
                if (hasnext)
                {
                    // we have number two
                    string fileTwo = files.Current;
                    // do the work
                    MergeSort(fileOne, fileTwo);
                    hasnext = files.MoveNext();
                }
            }
        } while (processed > 1);
        var lastfile = Directory.EnumerateFiles(sortdir).GetEnumerator();
        lastfile.MoveNext();
        return lastfile.Current; // by magic is the name of the last file
    }
