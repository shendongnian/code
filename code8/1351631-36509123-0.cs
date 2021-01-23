    List<string> colors = new List<string>() { "Select", "Red", "Blue", "Green", "Yellow" };
    List<ComboBox> combos = new List<ComboBox>();
    public Form1() {
      InitializeComponent();
      combos.AddRange(new ComboBox[] { comboBox1, comboBox2, comboBox3, comboBox4 });
      foreach (ComboBox cb in combos) {
        cb.Items.AddRange(colors.ToArray());
        cb.SelectedIndex = 0;
        cb.SelectedIndexChanged += cb_SelectedIndexChanged;
      }
    }
    void cb_SelectedIndexChanged(object sender, EventArgs e) {
      List<string> selectedColors = new List<string>();
      foreach (ComboBox cb1 in combos) {
        if (cb1.SelectedIndex > 0) {
          selectedColors.Add(cb1.SelectedItem.ToString());
        }
        foreach (ComboBox cb2 in combos.Where(x => !x.Equals(cb1))) {
          if (cb2.SelectedIndex > 0) {
            if (cb1.Items.Contains(cb2.SelectedItem.ToString())) {
              cb1.Items.Remove(cb2.SelectedItem.ToString());
            }
          }
        }
      }
      foreach (ComboBox cb in combos) {
        foreach (string c in colors) {
          if (!selectedColors.Contains(c) && !cb.Items.Contains(c)) {
            cb.Items.Add(c);
          }
        }
      }
    }
