    private void button1_Click(object sender, EventArgs e)
    {
      var results = await Task.Run(() => SomeLongRunningMethod("get"));
      foreach(string result in results)
      {
        this.Controls.Add(new Label() { Text = result; Location = new Point(5, (5 * DateTime.Now.Millisecond)); });
      }
    }
    public List<string> SomeLongRunningMethod(string value)
    {
      var results = new List<string>();
      if(value == "get")
      {
        // Do work.
        results.Add("blah");
      }
      return results;
    }
