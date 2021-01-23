    foreach (Control item in this.Controls)
    {
                if (item is TextBox)
                    Console.WriteLine("TextBox:" + item.Name);
                else
                    Console.WriteLine(item.GetType().Name + ":" + item.Name);
   }
 
