     public  FrmThickBox(Form owner, string message)
     {
        this.Owner = owner;
        this.Width = owner.Width;
        this.Height = owner.Height;
        this.Top = owner.Top;
        this.Left = owner.Left;
        this.thickBoxControl.Text = message;
        this.thickBoxControl.Size = new Size((int)this.Width / 2, (int)this.Height / 3);
        this.thickBoxControl.Top = (int)((this.Height - thickBoxControl.Height) / 2);
        this.thickBoxControl.Left = (int)((this.Width - thickBoxControl.Width) / 2);
     }
