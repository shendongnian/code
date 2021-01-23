    List<Form1> form1List = new List<Form1>();
    for (int i = 0; i < 10; i++)
    {
        Form1 frm = new Form1();
        frm.Name = "Form1_Instance_" + i.ToString();
        frm.Text = frm.Name;
        frm.Tag = i;
        // Do not show it
        // frm.Show(); 
        // Add it to your list
        form1List.Add(frm);
    }
    
    // Now suppose that your code has a TextBox from which your user types the ID of the form
    
    string temp = TextBox1.Text;
    int num;
    if (Int32.TryParse(temp, out num))
    {
        if(num >= 0 && num <= 9)        
        {
           Form1 f = form1List.FirstOrDefault(x => x.Tag.ToString() == num.ToString());
           if(f != null)
               f.Show();
        }
    }
    
