    int[] stopWordArray = new int[drplstGetDb.Items.Count];
    int i = 0;
    foreach(ListItem listItem in drplstGetDb.Items)
    {
        if (listItem.Selected)
        {
            stopWordArray[i] = Convert.ToInt32(listItem.Value.ToString()); //something like this
            i++;
        }
    }
    
