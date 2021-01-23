    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Store the question number and answer.
        Dictionary<int, string> Answers = new Dictionary<int, string>();
        //Loop through the radio button lists within your panel
        int i = 1; //used to determine the question number
        foreach (var rdbl in MyPanel.Controls.OfType<RadioButtonList>())
        {
            Answers.Add(i, rdbl.SelectedValue.ToString());
            i++;
        }
        //Do something with your stored answers.
    }
