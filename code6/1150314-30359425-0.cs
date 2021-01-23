            myPane.YAxis.Title.Text = "Nominees";
            myPane.XAxis.Title.Text = "Votes";
            // Make up some random data points
            
            string[] labels= new string[count];
            //string[] labelx = new string[count];
            for (int i = count-1; i >= 0; i--)
            {
                labels[counter] = voternames[i];
                counter++;
            }
            
            for (int i = count1-1; i >= 0; i--)
            {
                y0[counter1] = Convert.ToDouble(votes[i]);
                counter1++;
            }
            for (int i = 0; i < y0.Length; i++)
            {
		//Adding the x axis data and using y axis as a source to color a single bar
                list.Add(y0[i], i / 2.0);
            }
            
            Color[] colors = new Color[] {Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Purple};
            
	    // Generate a bar with point pair list in the legend
            BarItem myBar = myPane.AddBar("", list, Color.Green);
            
	    // Giving ref of color array
	    myBar.Bar.Fill = new Fill(colors);
	    
	    //Setting to fill with using point values of y axis
            myBar.Bar.Fill.Type = FillType.GradientByY;
            
	    //Setting min and max range is important
            myBar.Bar.Fill.RangeMin = 0;
            myBar.Bar.Fill.RangeMax = Convert.ToInt32(y0[0]);
            // Draw the X tics between the labels instead of 
            // at the labels
            myPane.YAxis.MajorTic.IsBetweenLabels = false;
            // Set the XAxis labels
            myPane.YAxis.Scale.TextLabels = labels;
            // Set the XAxis to Text type
            myPane.YAxis.Type = AxisType.Text;
            myPane.BarSettings.Base = BarBase.Y;
            // Fill the Axis and Pane backgrounds
            //myPane.Chart.Fill = new Fill(Color.White,Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            // Tell ZedGraph to refigure the
            // axes since the data have changed
            
            zgc.AxisChange();
            zgc.Refresh();
