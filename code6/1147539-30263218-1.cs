    int h = 5;
    int l = 5;       
    private void addButton_Click(object sender, EventArgs e)
    {
        Point newLoc = new Point(h, l);
        List<Button> buttons = new List<Button>();
        Button newButton = new Button();
        newButton.Text = buttonNameTextBox.Text;
        newButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(199)))), ((int)(((byte)(13)))));
        newButton.Size = new Size(150, 50);
        newButton.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        newButton.Location = newLoc;
        newLoc.Offset(0, newButton.Height + 5);
        newButton.
        buttons.Add(newButton);
        newButton.Name = componentNameTextBox.Text;
        this.Controls.Add(newButton);
        l += 65;
        newButton.Click += (s, ea) => {
            //Here is an event handler just for this button.  You can access
            //the surrounding variables (such as l, or newButton.BackColor etc) right here.
        };
    }
