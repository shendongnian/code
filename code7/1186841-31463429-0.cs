    foreach(Control cbxList in this.Controls)
    {
        if(cbxList is CheckBox)
        {
            for (int i = 0; i < cbxList.Items.Count; i++)
            {
                if ((string)cbxList.Items[i] == value)
                {
                    cbxList.SetItemChecked(i, true);
                }
            }
        }
    }
