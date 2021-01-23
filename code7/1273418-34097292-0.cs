    var item = ((MenuItem)sender).CommandParameter as User;
    if (item != null)
    {
         MessageBox.Show(item.DateRequired + " Item's Double Click handled!");
    }
