    {
        Business item=new Business() { Name="Yoko" };
        //
        BusinessForm dlg=new BusinessForm();
        dlg.Business=item;
        if (dlg.ShowDialog()==DialogResult.OK)
        {
            item=dlg.Business;
        }
    }
