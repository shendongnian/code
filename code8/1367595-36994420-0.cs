    for (int i = 0; i < elemList.Count; i++)
    {
        if (elemList[i].Attributes != null
         && elemList[i].Attributes["Name"] != null)
        {
            listBox1.Items.Add(elemList[i].Attributes["Name"].Value);
        }
    }
