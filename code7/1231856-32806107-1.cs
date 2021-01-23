    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string _path = "Employee.txt";
            string EmployeeData = File.ReadAllText(_path);
            if (EmployeeData.Contains(textDelete.Text))
            {
                System.IO.File.Delete(Path.GetFullPath(_path));
            }
        }
        catch
        {
            MessageBox.Show("File or path not found or invalid.");
        }  
    }
