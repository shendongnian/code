     string item;
     for (int index = 0; index < listBox1.Items.Count; index++) {
         item = listBox1.Items[index].ToString();
         texteditor.Documents.Open(@item);
         // do something with index
     }
