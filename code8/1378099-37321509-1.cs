    string oldSumValue = tbxSum.Text;
 
    try
    {
        // your code          
    }
    catch
    {
        tbxSum.Text = oldSumValue ;
        MessageBox.Show("Invalid Sum");       
    }
