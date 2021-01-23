    public void Initialize()
    {
        this.Text = "WinForm Console Application";
        SuspendLayout();
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(129, 112);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(35, 13);
        label1.TabIndex = 0;
        label1.Text = "label1";
        label1.Show();
        this.Controls.Add(label1); //very very very important line!
        ResumeLayout(false);
        PerformLayout();
    }
 
