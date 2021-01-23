    private void button1_Click(object sender, EventArgs e)
    {
        string[] lines = File.ReadAllLines(fileName);
        // Clear the existing rows
        tableLayoutPanel1.RowStyles.Clear();
        for (int i = 0; i < lines.Length; i++)
        {
            // Add a new row
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            // Create the TextBox
            TextBox txt = new TextBox();
            // Add any initializations for the text box here
            txt.Text = lines[i];
            // Create the button
            Button btn = new Button();
            // Add any initializations for the button here
            btn.Text = i.ToString();
            // Handle the button's click event
            btn.Click += btn_Click;
            // This value helps the button know where it is and which TextBox it is associated to
            btn.Tag = new object[] { i, txt };
            btn.Width = 30;
            
            // Add the controls to the created row
            tableLayoutPanel1.Controls.Add(txt, 0, i);
            tableLayoutPanel1.Controls.Add(btn, 1, i);
        }
    }
    void btn_Click(object sender, EventArgs e)
    {
        object[] btnData = (object[]) ((Control) sender).Tag;
        
        // The values are inside the sender's Tag property
        ReplaceLineInFile(fileName, (int)btnData[0], ((TextBox)btnData[1]).Text);
    }
