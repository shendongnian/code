    private Label newLabel;
    private TextBox nameTextBox;
    private string[] newLabelText = {"Name", "Height", "Color"};
    private int newLabelPositionX = -3;
    private int newLabelPositionY = 5;
    private int nameTextBoxPositionX = 74;
    private int nameTextBoxPositionY = 2;
    private int previousValue = 0;
    private int difference = 0;
    private int nameSuffix1 = 1;
    private int nameSuffix2 = 1;
    bool valueIncreased;
    private void numberOfRegions_ValueChanged(object sender, EventArgs e)
    {            
        int currentValue = Convert.ToInt32(numberOfRegions.Value);                        
        int numberOfLabels = 3;            
        if (currentValue > previousValue)
        {
            difference = currentValue - previousValue;
            previousValue = currentValue;
            valueIncreased = true;
        }
        else
        {
            difference = previousValue - currentValue;
            previousValue = currentValue;
            valueIncreased = false;
        }
        if (currentValue == 0)
        {
            colorPanel.Visible = false;
        }
        if (!valueIncreased)
        {
            for (int d = 0; d < difference; d++)
            {                   
                colorPanel.Controls.RemoveByKey("textBox" + (nameSuffix1 - 1));
                nameSuffix1--;
                if (nameTextBoxPositionY > 2)
                {
                    nameTextBoxPositionY -= 78;
                }
                for (int t = 0; t < numberOfLabels; t++)
                {                        
                    colorPanel.Controls.RemoveByKey("label" + (nameSuffix2 - 1));
                    nameSuffix2--;
                    if (newLabelPositionY > 5)
                    {
                        newLabelPositionY -= 26;
                    }
                }
            }
        }
        else
        {
            colorPanel.Visible = true;
            for (int i = 0; i < difference; i++)
            {
                nameTextBox = new TextBox();
                nameTextBox.Name = "textBox" + nameSuffix1;
                nameSuffix1++;
                nameTextBox.Size = new System.Drawing.Size(81, 20);
                nameTextBox.Location = new System.Drawing.Point(nameTextBoxPositionX, nameTextBoxPositionY);
                colorPanel.Controls.Add(nameTextBox);
                nameTextBoxPositionY += 78;
                for (int a = 0; a < numberOfLabels; a++)
                {
                    newLabel = new Label();
                    newLabel.Name = "label" + nameSuffix2;
                    nameSuffix2++;
                    newLabel.Location = new System.Drawing.Point(newLabelPositionX, newLabelPositionY);
                    newLabel.Text = newLabelText[a];
                    colorPanel.Controls.Add(newLabel);
                    newLabelPositionY += 26;
                }
            }            
        }           
    }
