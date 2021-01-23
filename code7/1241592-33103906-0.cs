    public void Gridview_ShowHide(Object o, EventArgs e) 
    {
        gv1.Visible = gv2.Visible = gv3.Visible = gv4.Visible = false;
        switch (DropDownList1.SelectedValue)
        {
             case 'gv1':
                  gv1.Visible = True;
                  break;
             case 'gv2':
                  gv2.Visible = True;
                  break;
             case 'gv3':
                  gv3.Visible = True
                  break;
             case 'gv4':
                  gv4.Visible = True;
                  break;
        }
    }
