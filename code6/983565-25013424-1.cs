    public List<String> results = new List<String>();
    
    private void button1_Click(object sender, EventArgs e)
    {
        var results = await SomeLongRunningMethodAsync("get");
        //Flow continues here once the long running operation has completed
        foreach(string result in results)
        {
          this.Controls.Add(new Label() { Text = result; Location = new Point(5, (5 * DateTime.Now.Millisecond)); });
        }
    }
    
    public async Task<List<string>> SomeLongRunningMethodAsync(string value)
    {
        //This is the long running operation
        //Mind you, this executes on a separate thread. 
        return await Task<List<string>>.Factory.StartNew(() =>
        {
          List<string> results = new List<string>();
          if(value == "get") 
          {
            //do work
          }
          return results;
        });
    }
