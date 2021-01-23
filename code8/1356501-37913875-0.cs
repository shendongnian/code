    using System;
    using System.Drawing;
    using System.Windows.Forms;
    class MyProgressBar : Control 
    {
    public MyProgressBar() 
    {
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.SetStyle(ControlStyles.Selectable, false);
        Maximum = 100;
        this.ForeColor = Color.Red; //This is where you choose your color
        this.BackColor = Color.White;
    }
    public decimal Minimum { get; set; }
    public decimal Maximum { get; set; }
    private decimal mValue;
    public decimal Value 
    {
        get { return mValue; }
        set { mValue = value; Invalidate(); }
    }
    protected override void OnPaint(PaintEventArgs e) 
    {
        var rc = new RectangleF(0, 0, (float)(this.Width * (Value - Minimum) / Maximum), this.Height);
        using (var br = new SolidBrush(this.ForeColor)) 
        {
            e.Graphics.FillRectangle(br, rc);
        }
        base.OnPaint(e);
    }
    }
