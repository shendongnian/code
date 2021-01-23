    private void label1_DoubleClick(object sender, EventArgs e)
    {
        // sender is the label that received the double click:
        Debug.Assert(Object.ReferenceEquals(sender, this.label1));
        Label doubleClickedLabel = (Label)Sender;
        var Id = doubleClickedLabel.Text;
        int personID;
        if (!String.IsNullOrWhiteSpace(Id) && int.TryParse(Id, out personID))
        {   // open form. Note the use of the using statement
            using (Form frm = new Form(_controller, personID)
            {
                frm.ShowDialog();
            }
        }
        else 
        {
            using (Form2 frm2 = new Form2())
            {
                frm2.ShowDialog();
            }
        }
    }
