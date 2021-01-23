    CustomLabel cl = new CustomLabel();
    cl.FromPosition = chart.Series[0].Points[0].XValue;  // some values, which will place 
    cl.ToPosition = chart.Series[0].Points[1].XValue;    // the cl between two points
    cl.Text = "";   // no text, please!
    cl.Image = "img01";  // this is our NamedImage
            
    ax.CustomLabels.Add(cl);  // now we can add the CL
