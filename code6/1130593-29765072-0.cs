    string line, new_line;
    using (StreamReader sr = new StreamReader(txtFilePath.Text))             
    using (StreamWriter sw = new StreamWriter(txtResultFolder.Text.ToString() +
                                              "\\" + "NEW_trimmed_file" + ".csv", true))
    {
       while ((line = sr.ReadLine()) != null)
       {
          new_line = line.TrimEnd();
          MessageBox.Show(new_line);
          sw.WriteLine(new_line);
       }
       sw.Flush();
    }
