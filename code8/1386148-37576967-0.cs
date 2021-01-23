    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
    {
        if ( double.IsNaN(e.NewPosition)  &&  double.IsNaN(e.NewPosition))
        {
            Console.WriteLine(e.Axis.AxisName + " axis reset.");
            // doYourThing
        }
    }
