    {
        int[] sortArray = new int[listBox2.Items.Count];
        for (int i = 0; i < listBox2.Items.Count; i++)
        {
            string sort = listBox2.GetItemText(i);
            sortArray[i] = int.Parse(sort);
        }
        int aantal = listBox2.Items.Count;
    
        listBox2.Items.Clear();
    
        Array.Sort(sortArray);
        foreach(var i in sortArray)
            listBox2.Items.Add(i);
    }
