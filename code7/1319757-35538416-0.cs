    var label = new Label();
    label.DataBindings.Add(new Binding("Tag", yourBindingSource, "DataField"));
    var panel = new Panel();
    panel.Controls.Add(label);
    this.Controls.Add(panel);
    MessageBox.Show(string.Format("{0}", label.Tag));
