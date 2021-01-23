    foreach (int item in ItemList)
    {
        if (listBoxOne.Items == null)
        {
            listBox1.Items.Add("Number " + item.ToString());
        }
        else
        {
            listBox1.Items.Add(",\n" + "Number " + item.ToString());
        }
        //Or more simply below
        listBoxOne.Items.Add = listBoxOne.Items == null ? ("Number " + item.ToString()) : (",\n" + "Number " + item.ToString());
