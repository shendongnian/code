    private void MyClick(object sender, EventArgs e) {
      ...
    }
    private void MyForm_Load(object sender, EventArgs e) {
      foreach (Control control in myPanel.Controls)
        control.Click += MyClick;
      ...      
    }
