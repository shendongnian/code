    for (int i = 0; i < elemList.Count; i++)
    {
        if (elemList[i].Name != null)
        {
            listBox1.Items.Add(elemList[i].Attributes["Name"].Value);
        }
    }
