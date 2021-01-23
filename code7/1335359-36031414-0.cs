    foreach (Control ctrl in Table1.Controls)
    {
        if (ctrl is RadioButtonList)
        {  
        RadioButtonList rbl = (RadioButtonList)ctrl;
        for (int i = 0; i < rbl.Items.Count; i++)
        {
            if (rbl.Items[i].Selected)
            {
               GATotal+= RadioButtonList.SelectedIndex;
              
            }
        }
    }
}
