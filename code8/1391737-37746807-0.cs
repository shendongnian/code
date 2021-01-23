    private void chartControl1_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
    {
        AxisBase axis = e.Item.Axis;
        if (axis is AxisX)
        {
           e.Item.Text =  e.Item.Text.Substring(0,2) ;
        }
    }
