    if(listBox1.Items.Count == listBox3.Items.Count)
    {
         int rowCount = listBox1.Items.Count;
         listBox4.Items.Clear();
         for (int i=0; i < rowCount; i++)
         {
                ppc[i] = Convert.ToInt32(listBox3.Items[i]);
                qty[i] = Convert.ToInt32(listBox1.Items[i]);
                listBox4.Items.Insert(i , (ppc[i] * qty[i]));
         } 
    }
