    private void Init()
    {
          ...
          this.comboBox1.SelectedIndexChanged +=
               new System.EventHandler(ComboBox1_SelectedIndexChanged);
    }
    
    private void ComboBox1_SelectedIndexChanged(object sender,
            System.EventArgs e)
    {
          //other event code
          ...
          var comboBox = (ComboBox)sender;
          var port = (string)comboBox1.SelectedItem;
          Properties.Settings.Default.Setting = port;
          Properties.Settings.Default.Save();
          ...
    }
