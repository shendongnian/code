    radioButtons = new List<RadioButton>();
    for (int i = 7; i < output.Count(); i++)
    {                   
        radioButtons[i] = new RadioButton();
        radioButtons[i].Text = output[i];
        radioButtons[i].Location = new System.Drawing.Point(10, 30 + (i - 7) * 30);
        radioButtons[i].Name = "radioButton" + i.ToString();
        radioButtons[i].AutoSize = true;
        this.Controls.Add(radioButtons[i]);
        Console.Write(output[i]);
    }
