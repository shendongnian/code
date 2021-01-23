    public void MergeLists(List<Deliverable> a, List<Deliverable> b)
    {
        int index1 = 0;
        int index2 = 0;
        while (true)
        {
            // if the end of the 'a' list has been reached, then add
            // everything from the 'b' list and break from the loop
            if (index1 >= a.Count()) {
                for (index2; index2 < b.Count(); ++index2) {
                    FinalDeliverables.Add(b[index2]);
                }
                break;
            }
            // if the end of the 'b' list has been reached, then add
            // everything from the 'a' list and break from the loop
            if (index2 >= b.Count()) {
                for (index1; index1 < a.Count(); ++index1) {
                    FinalDeliverables.Add(a[index1]);
                }
                break;
            }
            if (a[index1].ID > b[index2].ID)
            {
                FinalDeliverables.Add(a[index1]);
                index1++;
            }
            else if (a[index1].ID < b[index2].ID)
            {
                FinalDeliverables.Add(a[index2]);
                index2++;
            }
            else if (a[index1].ID == b[index2].ID)
            {
                FinalDeliverables.Add(a[index1]);
                FinalDeliverables.Add(a[index2]);
                index1++;
                index2++;
            }
        }
    }
