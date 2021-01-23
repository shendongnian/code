    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
    	    if (System.IO.File.Exists(Path.GetFullPath(@"Employee.txt"))
    		{
    			string EmployeeData = File.ReadAllText("Employee.txt");
    			if (EmployeeData.Contains(textDelete.Text))
    			{
    				System.IO.File.Delete(Path.GetFullPath("Employee.txt"));
    			}
    		}
        }
        catch
        {
            MessageBox.Show("File or path not found or invalid.");
        }  
    }
