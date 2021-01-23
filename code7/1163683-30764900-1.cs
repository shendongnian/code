    int buttonSize = 20;
    Panel myPanel = (Panel)this.Controls["panelArea"];
    string[] myGrid = getGrid(0);
    for (int row = 0; row < r; row++)
    {
         char[] rowChar = myGrid[row].ToCharArray();
         for (int col = 0; col < c; col++)
         {
            Button newButton = new Button();
            newButton.Name = "grid" + row.ToString("D3") + col.ToString("D3");
            newButton.Location = new Point { X = buttonSize * col, Y = buttonSize * row };
            newButton.Size = new Size { Width = buttonSize, Height = buttonSize };
            newButton.Text = rowChar[col].ToString();
            if (rowChar[col] == '%') newButton.BackColor = Color.Green;
    
            myPanel.Controls.Add(newButton);
            Debug.WriteLine(newButton.Location);
         }
      }
