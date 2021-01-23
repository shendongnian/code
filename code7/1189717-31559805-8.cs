    List<int> rids = null;
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        rids = new List<int>()
        {
           RandomNumber(-111, 999),
           RandomNumber(-111, 999),
           RandomNumber(-222, 888),
           RandomNumber(-333, 777),
           RandomNumber(-222, 777),
           RandomNumber(-333, 444),
           RandomNumber(-555, 888),
           RandomNumber(444, 999),
           RandomNumber(111, 222),
           RandomNumber(222, 333)
        };         
    
        DisplayValues();  // use it if you want to show your values in UI
    
    }
    
    protected void sortButton_Click(object sender, EventArgs e)
    {
       rids.Sort();
    
       DisplayValues()
    }
    
    private void DisplayValues()
    {
       for (int i = 0; i < Controls.Count; i++)
       {
           if (Controls[i] is TextBox) if(Controls[i]).ID.Contains("txt"))
           (Controls[i] as TextBox).Text = rids[Int32.Parse(Controls[i].ID.Replace("txt", "")) - 1].ToString();
       }
    }
