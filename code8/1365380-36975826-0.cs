    string Name = string.Empty;
    for (int i=0; i<3; ++i)
    {
        try
        {
            Name = Folder + "SO36922336-" + i.ToString() + ".txt";
            StreamWriter sw = new StreamWriter(Name);
            sw.WriteLine("File created using StreamWriter class.");
            sw.Close();
            sw.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message + "\r\n" + Name);
        }
    }
