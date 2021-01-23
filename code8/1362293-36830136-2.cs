    private void btnAccept_Click(object sender, EventArgs e)
    {
        formPopup.time = timePicker.Value.ToShortTimeString();
    
        Label newLabel = new Label();
        newLabel.Text = formPopup.time;
        newLabel.Location = new Point(_buttonLocation.X + 100, _buttonLocation.Y);
        
        formTimeTable.CMonTime++;
        newLabel.Size = new System.Drawing.Size(100, 25);
        newLabel.ForeColor = System.Drawing.Color.White;
        thisParent.Controls.Add(newLabel);
    
        this.Close();
    }
