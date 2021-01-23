        void btnSubmitCountParticipant_Click(object sender, EventArgs e)
    {
        StringBuilder sbparticipantName=new StringBuilder();
        try
        {
            int numberofparticipants = Convert.ToInt32(drpNoofparticipants.SelectedValue);
            ViewState["numberofparticipants"] = numberofparticipants;
            Table tableparticipantName = new Table();
            int rowcount = 1;
            int columnCount = numberofparticipants;
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            TextBox txtNameofParticipant = new TextBox();
            txtNameofParticipant.ID = "NameTest";
            txtNameofParticipant.Text = "This is a textbox";
            cell.ID = "cellTest";
            cell.Controls.Add(txtNameofParticipant);
            row.Cells.Add(cell);
            tableparticipantName.Rows.Add(row);
            panelNameofParticipants.Controls.Add(tableparticipantName);
        }
        catch(Exception ex)
        { // please put a breakpoint here, so that we'll know if something occurs, 
        }
    }
    public void CreateControls()
    {
        try
        {
            //String test1 = test.Value;
            List<string> listParticipantName = new List<string>();
            //if (ViewState["numberofparticipants"] != null)
            //{
            string findcontrol = "NameTest";
            TextBox txtParticipantName = (TextBox)panelNameofParticipants.Controls["NameText"];
            //check if get what we want. 
            listParticipantName.Add(txtParticipantName.Text);
            //}
        }
        catch (Exception ex)
        {// please put a breakpoint here, so that we'll know if something occurs, 
        }
    }
