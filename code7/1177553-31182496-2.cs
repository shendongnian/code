        // directly anchored to a point
        TextAnnotation TA1 = new TextAnnotation();
        TA1.Text = "DataPoint 222";
        TA1.SetAnchor(chart2.Series["UnitPrice"].Points[222]);
        chart2.Annotations.Add(TA1);
        // anchored to a point but shifted down
        TextAnnotation TA2 = new TextAnnotation();
        TA2.Text = "DataPoint 111";
        TA2.AnchorDataPoint = chart2.Series["UnitPrice"].Points[111];
        TA2.AnchorY = 0;   
        chart2.Annotations.Add(TA2);
        // this one is not anchored on a point:
        TextAnnotation TA3 = new TextAnnotation();
        TA3.Text = "At 50% width BC";
        TA3.AnchorX = 50;  // 50% of chart width
        TA3.AnchorY = 20;  // 20% of chart height, from top!
        TA3.Alignment = ContentAlignment.BottomCenter;  // try a few!
        chart2.Annotations.Add(TA3);
