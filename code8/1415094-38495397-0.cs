            try
            {
        listBox1.Items.Clear();
            string a = "";
            
            a = "";
           a = listView1.SelectedItems[0].SubItems[0].Text;
               
           StreamReader oku = new StreamReader(strPath+"\\"+"Versiyonlar"+"\\"+a);
           string OkunanVeri = oku.ReadToEnd();
           string[] dizi = OkunanVeri.Split(new string[]{"\r\n"},StringSplitOptions.RemoveEmptyEntries);
           foreach (var item in dizi)
           {
               listBox1.Items.Add(item);
           } 
                oku.Close();
            }
            catch 
            {
              
            }
