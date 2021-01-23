    using System.Windows.Forms;
    
    
    {
    
    private void info_Click(object sender, EventArgs e)
        {
    
            string line = System.IO.File.ReadAllText("Bedienungsanleitung.txt"); // Solution Exxplorer Rechtsklick add text file
    
            MessageBox.Show(line);  // has optional params for icon type, caption, buttons available, etc
        } 
    
    
    
    }
