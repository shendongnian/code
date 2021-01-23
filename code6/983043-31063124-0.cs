    private void Form_Load(object sender, EventArgs e)
    {
       foreach (var item in this.Controls)
       {
          if (item.GetType() == typeof(RadioButton))
             ((RadioButton)item).TabStopChanged += new System.EventHandler(TabStopChanged);
       }
    }
