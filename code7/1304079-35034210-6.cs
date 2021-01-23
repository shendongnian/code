    void addQuestion(FlowLayoutPanel flp, int nr)
    {
        Label l1 = new Label();
        l1.AutoSize = true;
        l1.Font = new System.Drawing.Font("Consolas", 9f, FontStyle.Bold);
        l1.Text = "Q" + nr.ToString("00") + ":";
        l1.Margin = new System.Windows.Forms.Padding(0, 5, 10, 0);
        flp.Controls.Add(l1);
        Label l2 = new Label();
        l2.Text = randString(50 + R.Next(150));
        l2.Left = l1.Right + 5;
        l2.AutoSize = true;
        l2.Margin = new System.Windows.Forms.Padding(0, 5, 10, 0);
        // limit the size so that it fits into the flp; it takes a little extra
        l2.MaximumSize = new System.Drawing.Size(flp.ClientSize.Width - 
               l2.Left - SystemInformation.VerticalScrollBarWidth  - l2.Margin.Right * 2, 0);
        flp.Controls.Add(l2);
        flp.SetFlowBreak(l2, true);
    }
