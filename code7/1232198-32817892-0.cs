    var lines = System.IO.File.ReadAllLines(@"D:\Test.txt");
    lines.ToList()
         .ForEach(item =>
         {
             var index = this.checkedListBox1.Items.IndexOf(item);
             if(item >=0)
                 this.checkedListBox1.SetItemChecked(index, true);
         });
