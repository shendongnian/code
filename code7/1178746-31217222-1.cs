    private void AddButton_Click(object sender, EventArgs e)
    {
        // show second form
        frm2.ShowDialog()
        // get input values (upon clicking on "OK" and closing the second form)
        var NetworkName = frm2.myData.NetworkName;
        var SecurityType = frm2.myData.SecurityType;
        ...
        // handle them
    }
