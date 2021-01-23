    private void CreatetopPipes(int Number)
    {
        for (int i = 0; i <= Number; i++)
        {
    
            PictureBox temp = new PictureBox();
            panelName.Controls.Add(temp);
            temp.Width = 50;
            temp.Height = 350;
            temp.BorderStyle = BorderStyle.FixedSingle;
            temp.BackColor = Color.Red;
            temp.Top = temp.Height * panelName.Controls.Count;
            temp.Left = 300;
            topPipe[i] = temp;
            topPipe[i].Visible = true;
    
        }
    }
