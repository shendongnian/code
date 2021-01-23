    private void acNewTypeButton_Click(object sender, EventArgs e)
    {
        var acType = db.ACTypes
                    .FirstOrDefault(a => a.ACType1 == acAddNewTextBox.Text.ToString());
        // If it doesn't exist, add it.
        if (acType == null){
            acType = new ACType();
            acType.ACType1 = acType.Text.ToString();
            db.ACTypes.InsertOnSubmit(acType);
            db.SubmitChanges();
            acAddNewTextBox.Text = "";
        }
        // Already exists
        else{
            MessageBox.Show("AC Type already exists.");
        }
        loadDataGrid();
    }
