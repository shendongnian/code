     foreach (string subFich in SubFicheiros)
    {
        listBox.Items.Add("- Deleting File: " + subFich.Substring(Pasta.Length + 1, subFich.Length - Pasta.Length - 1));
        ficheirosEncontrador++;
    }
    try
    {
    var di = new DirectoryInfo(Pasta);
    di.Attributes &= ~FileAttributes.ReadOnly;
     Directory.Delete(Pasta, true);
    }
    catch (Exception EE)
    {
     MessageBox.Show("Error: "+ EE.toString());
    }
       
