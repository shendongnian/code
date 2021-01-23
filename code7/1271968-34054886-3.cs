    private void ComboBoxTestForm_Paint(object sender, PaintEventArgs e)
    {
        //detect color based on selected index of colorComboBox
        //Create your brush and your pen
        //detect shape based on selected index of imageComboBox
        //draw shares using e.Graphics.DrawXXXX and e.Graphics.FillXXXX
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
