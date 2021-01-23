    private bool flag;
    private void Smalltubbutton1_Click(object sender, EventArgs e)
    {
        System.Drawing.Bitmap bitmap1;
    
        if (flag)
        {
            bitmap1 = WindowsFormsApplication21.Properties.Resources.GRAYSCALEsmalltub;
        }
        else
        {
            bitmap1 = WindowsFormsApplication21.Properties.Resources.smalltub      
        }
        flag = !flag;
    }
