    for (int i = 0; i < ProjectCounter; ++i)
    {
        radioButtons[i] = new RadioButton();
        radioButtons[i].TabIndex = i + 1;
        radioButtons[i].Name = "ProjectListItem[i].MSSQLDatabase";
        radioButtons[i].Text = "ProjectListItem[i].MSSQLDatabase";
        radioButtons[i].Location = new System.Drawing.Point(10, 10 + i * 20);
        radioButtons[i].CheckedChanged += new EventHandler(rdo_CheckedChanged);
        this.Controls.Add(radioButtons[i]);
    }
