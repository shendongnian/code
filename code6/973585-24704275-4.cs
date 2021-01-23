        for (int i = 0; i < listGroup.Count(); i++)
        {
            CheckBoxes[i] = new CheckBox();
            CheckBoxes[i].Text = listGroup.ElementAt(i).GroupName;
            CheckBoxes[i].Name = "txt" + listGroup.ElementAt(i).GroupName.Replace(' ', '_');
            CheckBoxes[i].CheckedChanged += new EventHandler(CheckBoxes[i] + "_CheckedChanged");
            CheckBoxes[i].Width = 200;
            //set location based on index of i
            CheckBoxes[i].Location = new System.Drawing.Point(5, 10 + (i * 30));
            this.Controls.Add(CheckBoxes[i]);
        }
