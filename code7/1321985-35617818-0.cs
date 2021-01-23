     private void button1_Click(object sender, EventArgs e)
        {
            string[,] name = new string[listView1.Items.Count,2];//  
            for(int i = 0; i < listView1.Items.Count; i++)       //
            {                                                    // This will insert the items from the listview to array
                name[i,0] = listView1.Items[i].Text;             //
                name[i, 1] = listView1.Items[i].SubItems[1].Text;//
            }                                                    //
            ucAddBook.pass(ref name);//called the method from parent and set name as reference in parameter
            this.Dispose();//this will trigger the parent to loop the array that i pass then insert in the listview
        }
