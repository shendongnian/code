    private void MyProcedure() 
    {
        for (i = 1; i <= 100; i++)
        {
            RadioButton_WallFirstStorey_Yes[i] = new RadioButton();
            RadioButton_WallFirstStorey_No[i] = new RadioButton();
            InitializeRadioButton_Wall(RadioButton_WallFirstStorey_Yes[i]);
            InitializeRadioButton_Wall(RadioButton_WallFirstStorey_No[i]);
            RadioButton_WallFirstStorey_Yes[i].Text = "Yes";
            RadioButton_WallFirstStorey_No[i].Text = "No";
            RadioButton_WallFirstStorey_Yes[i].Location = new Point(Panel_WallFirstStorey[i].Location.X + Panel_WallFirstStorey[i].Width / 3, Panel_WallFirstStorey[i].Location.Y);
            RadioButton_WallFirstStorey_No[i].Location = new Point(Panel_WallFirstStorey[i].Location.X + Panel_WallFirstStorey[i].Width * 2 / 3, Panel_WallFirstStorey[i].Location.Y);
            Panel_WallFirstStorey[i].Controls.Add(RadioButton_WallFirstStorey_Yes[i]);
            Panel_WallFirstStorey[i].Controls.Add(RadioButton_WallFirstStorey_No[i]);
        }
    }
