    private void ComboBoxTestForm_Paint(object sender, PaintEventArgs e)
    {
        //detect color based on selected index of colorComboBox
        //Create your brush and your pen
        //detect shape based on selected index of imageComboBox
        //draw shares using e.Graphics.DrawXXXX and e.Graphics.FillXXXX
       /*Suppose Color.Redis detected from selected index*/
        var myColor= Color.Red; 
        using ( var myPen = new Pen(myColor))
        {
            /*Suppose drawing ellipse is detected from selected index*/
            e.Graphics.DrawEllipse( myPen, 50, 50, 150, 150 );
        }
    }
    
    private void imageComboBox_SelectedIndexChanged(object sender, EventArgs e )
    {
        //Makes the form repaint
        this.Invalidate();
    }
    private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Makes the form repaint 
        this.Invalidate();        
    }
