    private void BtnCalc_Click(object sender, EventArgs e)
    {
        // Here I am declaring my variables and I am converting my data types.
    
        double length = Convert.ToDouble(LengthArea.Text);
        double width = Convert.ToDouble(WidthArea.Text);
    
        Shape shape = Shape.Triangle; // This value should be fetched from your combobox
    
        //Here I am performing the caluclations for and the perimiter and area.
        double Area = CalculateArea(shape, length, width);
        double perimeter = CalculatePerimiter(shape, length, width);
    
        //Here I am outputting calculations to labels. 
        string AreaAnswer.Text = Convert.ToString(Area);
        string AnswerPerimiter.Text = Convert.ToString(perimeter);
    }
