    struct DynamicFormControls
    {
        public TextBox textBox;
        public Label label;
    }
    DynamicFormControls dynamicControls = new DynamicFormControls();
    Stack<Control> controlStack = new Stack<Control>();
    private string[] newLabelText = {"Name", "Height", "Color"};
    private int newLabelPositionX = -3;
    private int newLabelPositionY = 5;
    private int nameTextBoxPositionX = 74;
    private int nameTextBoxPositionY = 2;
    private int numberOfLabels = 3;
    private int currentValue = 0;
    private int previousValue = 0;
    private int difference = 0;
    private int nameSuffix1 = 1;
    private int nameSuffix2 = 1;
    private void numberOfRegions_ValueChanged(object sender, EventArgs e)
    {
        currentValue = Convert.ToInt32(numberOfRegions.Value);
        if (currentValue == 0)
        {
            colorPanel.Visible = false;
            colorPanel.Size = new System.Drawing.Size(161, 10);
        }
        if (!ValueIncreased())
        {
            RemoveControls();
        }
        else
        {
            colorPanel.Visible = true;            
            CreateControls();
        }
    }
    private bool ValueIncreased()
    {
        if (currentValue > previousValue)
        {
            difference = currentValue - previousValue;
            previousValue = currentValue;
            return true;
        }
        else
        {
            difference = previousValue - currentValue;
            previousValue = currentValue;
            return false;
        }
    }
    private void CreateControls()
    {
        for (int i = 0; i < difference; i++)
        {
            dynamicControls.textBox = new TextBox();
            dynamicControls.textBox.Name = "textBox" + nameSuffix1;
            dynamicControls.textBox.Size = new System.Drawing.Size(81, 20);
            dynamicControls.textBox.Location = new System.Drawing.Point(nameTextBoxPositionX, nameTextBoxPositionY);                
            colorPanel.Controls.Add(dynamicControls.textBox);
            controlStack.Push(dynamicControls.textBox);
            nameTextBoxPositionY += 78;
            nameSuffix1++;                
            for (int a = 0; a < numberOfLabels; a++)
            {
                dynamicControls.label = new Label();
                dynamicControls.label.Name = "label" + nameSuffix2;
                dynamicControls.label.Location = new System.Drawing.Point(newLabelPositionX, newLabelPositionY);
                dynamicControls.label.Text = newLabelText[a];
                colorPanel.Controls.Add(dynamicControls.label);
                controlStack.Push(dynamicControls.label);
                newLabelPositionY += 26;
                nameSuffix2++;
            }
        }
    }
    private void RemoveControls()
    {
        for (int d = 0; d < difference; d++)
        {                
            for (int b = 0; b < 6; b++)
            {
                controlStack.Pop().Dispose();
            }
            nameSuffix1--;            
            if (nameTextBoxPositionY > 2)
            {
                nameTextBoxPositionY -= 78;
            }
            for (int t = 0; t < numberOfLabels; t++)
            {
                nameSuffix2--;
                if (newLabelPositionY > 5)
                {
                    newLabelPositionY -= 26;
                }
            }
        }
    }
