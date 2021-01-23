    private void dgKeyDown(object sender, KeyEventArgs e)
        {
            User a = null;
            if(e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                IDataObject dataObj = Clipboard.GetDataObject();
                if (dataObj !=null && dataObj.GetDataPresent(format.Name))
                {
                    a = dataObj.GetData(format.Name) as User;
                }
                dg1Users.Add(a);
            }
            else if (e.Key == Key.B && Keyboard.Modifiers == ModifierKeys.Control)
            {
                User copingUser = dg1.SelectedItem as User;
                if (copingUser != null)
                {
                    IDataObject dataObj = new DataObject();
                    dataObj.SetData(format.Name, copingUser, true);
                    Clipboard.SetDataObject(dataObj, true);
                }
            }
        }
