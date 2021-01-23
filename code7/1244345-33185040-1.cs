        // copy controls to list
        var list = new List<Control>();
        foreach (Control c in form.Controls)
        {
            list.Add(c);
        }
        Console.WriteLine("I have total of {0} controls\n", form.Controls.Count);
        int i = 0;
        // iterate over list
        foreach (Control c in list)
        {
            i++;
            this.Controls.Add(c);
            Console.WriteLine(" Number of controls rem {1}\n",
                              form.Controls.Count);
        }
        Console.WriteLine("I added a total of {0} controls and still have {1}\n",i,     
                           form.Controls.Count);
      
