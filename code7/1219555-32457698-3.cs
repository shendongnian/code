    static void Main()
    {    
        DialogResult dialogResult = MessageBox.Show("There is " + toReadableSize(freeSpaceInC) + " free in C: and " + toReadableSize(freeSpaceInD) + " free in D:. Do you want to continue the installation?", "MATLAB_R2008a_ENU_EU", MessageBoxButtons.YesNo);
    
        if (dialogResult == DialogResult.Yes)
        {
            Form1 fm1 = new Form1();
            fm1.ShowDialog();
            fm1.Close();
        }            
        else if (dialogResult == DialogResult.No)
        {
            Application.Exit();
        }
    }
    
    private static string toReadableSize(int size)
    {
        if(size < 1024)
            return size + "B";
            
        if(size < 1024*1024)
            return Math.Round(((float)size / 1024), 2) + "KB";
            
        if(size < 1024*1024*1024)
            return Math.Round(((float)size / (1024*1024)), 2) + "MB";
            
        return Math.Round(((float)size / (1024*1024*1024)), 2) + "GB";
    }
