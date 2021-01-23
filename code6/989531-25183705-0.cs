    foreach (var item in rowdata)
    { 
        if (!(this.chart1.ChartAreas[0].AxisX.CustomLabels.Contains(checkedListBox1.SelectedItem)))
        {
            if (e.NewValue == CheckState.Checked)
            {
                var s = new CustomLabel(temp + 1.5, m + 1.5, item, labelrow, LabelMarkStyle.LineSideMark);
    
                this.chart1.ChartAreas[0].AxisX.CustomLabels.Add(s);
    
            }
            else
            {
                // You can make this filter more specific if necessary
                var remLabel = this.chart1.ChartAreas[0].AxisX.CustomLabels
                    .SingleOrDefault(cl=>cl.FromPosition == temp + 1.5 
                                         && cl.ToPosition == m + 1.5);
                if (remLabel != null)
                    this.chart1.ChartAreas[0].AxisX.CustomLabels.Remove(remLabel);
            }
        }
        temp = m;
        m++;
    }
