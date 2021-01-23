    private void button1_Click(object sender, EventArgs e)
    {
         list1 = new List<int>(Enumerable.Range(5,5));
         list2 = new List<int>(Enumerable.Range(1,20));
    
         foreach (int num1 in list1)
         {
             listBox1.Items.Add(num1);
         }
    
         foreach (int num2 in list2)
         {
             bool numFound = false;
             foreach (int num1 in list1)
             {
                 if (num2 == num1)
                 {
                     numFound = true;
                     break;
                 }
             }
             if (!numFound)
                 listBox2.Items.Add(num2);
         }
    }
