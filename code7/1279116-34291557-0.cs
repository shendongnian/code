    private void checkLists()
    {
    int actualResultList1 = 0;
    int actualResultList2 = 0;
    // GET THE ONES FROM LIST 1
    for (int l1 = 0; l1 < List1.Count; l1++)
    {
        if (List1[l1] == 1)
        {
            actualResultList1++;
        }
    }
    // GET THE ONES FROM LIST 2
    for (int l2 = 0; l2 < List2.Count; l2++)
    {
        if (List2[l2] == 1)
        {
            actualResultList2++;
        }
    }
    if ((List1.Count + List2.Count) < 6)
    {
        if (actualResultList1 > (actualResultList2 + ((6/2) - List2.Count)))
        {
            MessageBox.Show("List1");
        }
        if (actualResultList2 > (actualResultList1 + ((6/2) - List1.Count)))
        {
            MessageBox.Show("List2");
        }
    }
    else
    {
        if (actualResultList1 > actualResultList2)
        {
            MessageBox.Show("List1");
        }
        else if (actualResultList2 > actualResultList1)
        {
            MessageBox.Show("List2");
        }
        else if (actualResultList1 == actualResultList2)
        {
            MessageBox.Show("equal");
        }
    }
    }
