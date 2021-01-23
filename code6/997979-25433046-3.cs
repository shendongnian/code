    var grad3 = new System.Windows.Media.GradientStop() 
                      {Offset = 0.5, Color=Colors.Blue};
    var grad4 = new System.Windows.Media.GradientStop() 
                      {Offset = 0.5, Color=Colors.Red};
    GradientStop2.Offset = 1;
    p_Fill.GradientStops.Add(GradientStop1);   
    p_Fill.GradientStops.Add(grad3);
    p_Fill.GradientStops.Add(grad4);
    p_Fill.GradientStops.Add(GradientStop2);
