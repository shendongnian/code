    using(System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath))
    {
       foreach(ListViewItem item in list_log.Items)
       { 
           string sLine = item.ToString();
           for(int i=0; i<item.SubItems.Count;i++)
           {
                sLine += item.SubItems[i].Text;                
           } 
           SaveFile.WriteLine(sLine);           
       }
    }
