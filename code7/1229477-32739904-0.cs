    using System.Windows.Forms;
    
    
    {
    
    private void info_Click(object sender, EventArgs e)
        {
    
            string line = System.IO.File.ReadAllText("Bedienungsanleitung.txt"); // Solution Exxplorer Rechtsklick add text file
            Console.Write(line);   
    
            MessageBox.Show(line);
        } 
    
    
    
    }
