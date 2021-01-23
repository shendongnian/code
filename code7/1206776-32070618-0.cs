    for(int i = 0; i < 3; i++)
    {
        var localCopy = i;
        parent.Items.Add(CreateMenuItem(localCopy.ToString(), () => MessageBox.Show(localCopy.ToString())));
    }
