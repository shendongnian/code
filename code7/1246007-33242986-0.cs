    public int[] selectedIndexesOfCheckBoxList(CheckBoxList chkList)
    {
        List<int> selectedIndexes = new List<int>();
        foreach (ListItem item in chkList.Items)
        {
            if (item.Selected)
            {
                selectedIndexes.Add(chkList.Items.IndexOf(item));
            }
        }
        return selectedIndexes.ToArray();
    }
