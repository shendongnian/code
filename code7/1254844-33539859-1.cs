    string address = "D:";
    DirectoryInfo di = new DirectoryInfo(address);
    try
      {
         foreach (var f in di.GetFiles("*", SearchOption.AllDirectories))
         {         
            richTextBox1.Document.Blocks.Clear();
            richTextBox1.Document.Blocks.Add(new Paragraph(new Run(f.DirectoryName + f.Name + " >> " + f.Length + "\n")));
         }
       }
    catch (Exception ex)
       {
           richTextBox1.Document.Blocks.Add(new Paragraph(new Run(ex.Message)));
       }
