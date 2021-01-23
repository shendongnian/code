    foreach (Control item in panel1.Controls)
    {
        if (item.Name == "testText")
        {
             panel1.Controls.Remove(item);
             break;
        }
    }
