    public void MergeLists(List<Deliverable> a, List<Deliverable> b)
    {
        int largeArrayCount = a.Count;
        int currentBIndex = 0;
        List<Deliverable> FinalResult = new List<Deliverable>();
        for (int i = 0; i < largeArrayCount; i++)
        {
            if (i < b.Count)
            {
                if (a[i].ID >= b[i].ID)
                {
                    // Add All elements of B Which is smaller than current element of A
                    while (a[i].ID <= b[currentBIndex].ID)
                    {
                        FinalResult.Add(b[currentBIndex++]);
                    }
                }
                else
                {
                    FinalResult.Add(a[i]);
                }
            }
            else
            {
                // No more elements in b so no need for checking
                FinalResult.Add(a[i]);
            }
        }
    }
