    public void CreateControls()
    {
        try
        {
	        Panel p1= (Panel)Cache["TempPanel"];
	        panelNameofParticipants.Controls.Add(p1);
            //String test1 = test.Value;
            List<string> listParticipantName = new List<string>();
            if (ViewState["numberofparticipants"] != null)
            {
                int numberofparticipants = Convert.ToInt32(ViewState["numberofparticipants"]);
                for (int i = 0; i < numberofparticipants; i++)
                {
                    string findcontrol = "txtNameofParticipant" + i;
                    TextBox txtParticipantName = (TextBox)panelNameofParticipants.FindControl(findcontrol);
                    listParticipantName.Add(txtParticipantName.Text);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
