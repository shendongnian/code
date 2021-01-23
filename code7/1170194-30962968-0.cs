    public async void button1_Click(object sender, EventArgs e)
    {                  
       label1.Text = "Parsing entries && initializing comms ...";
       await Apple();
    
       label1.Text = "No. of items: " + ((Listbox1.Items.Count).ToString());
    
       if (Listbox1.Items.Count >= 2)
       {
          Listbox1.SetSelected(1, true);
       }
    }
    public async Task Apple() 
    {
       await Task.Run(()=>
            {
               // serial comms work ...              
            }
       // add items to list here ...
    }
