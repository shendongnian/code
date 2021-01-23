    for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
                 {
                     this.checkedListBox2.SetItemChecked(i, true);   
                     checkedListBox2.Items[i]=checkedListBox2.Items[i].ToString().Replace("product","#product");
                 }
        
        for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
                 {
                     this.checkedListBox2.SetItemChecked(i, false);       
        checkedListBox2.Items[i]=checkedListBox2.Items[i].ToString().Replace("#product","product");                     
                 }
