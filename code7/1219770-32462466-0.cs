    int i = 1;
    foreach (var item in listView1.Items) {
        if (item.Selected == true) {
            label1.Text = "Number" + i;
        }
        i++;
    }
    //OR DO THIS
    for (int i = 1; i <= listView1.Items.Length; i++) {
        if (item.Selected == true) {
            label1.Text = "Number" + i;
        }
    }
