    string dir = Convert.ToString(folderBrowserDialog1.SelectedPath);
    DirectoryInfo di = new DirectoryInfo(dir);
    int asm = comboBox1.SelectedIndex + 1;
    int prt = comboBox2.SelectedIndex + 1;
    int drw = comboBox3.SelectedIndex + 1;
    var assembliesToBeDeleted = (from a in di.GetFiles("*.asm.*", SearchOption.TopDirectoryOnly)
                                         orderby a.LastWriteTime descending, a.Name ascending
                                         select a).ToArray();
     foreach (var assembly in assembliesToBeDeleted)
     {
          File.Delete(assembly);
          Console.WriteLine(assembly);
     }
