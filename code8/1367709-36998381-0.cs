    foreach (Control item in panel1.Controls)
    {
        if (item.Name == "txt1")
        {
             panel1.Controls.Remove(item);
             break;
        }
    }
