    private void ListView1_MouseClick(object sender, MouseEventArgs e)
    {
            if (this.ListView1.SelectedItems.Count > 0) {
                    this.TextBox1.Text = this.ListView1.SelectedItems[0].Text;
                    this.TextBox2.Text = this.ListView1.SelectedItems[0].SubItems[0].Text; //zero here
                    this.TextBox3.Text = this.ListView1.SelectedItems[0].SubItems[1].Text;
                    this.TextBox4.Text = this.ListView1.SelectedItems[0].SubItems[2].Text;
                    this.TextBox5.Text = this.ListView1.SelectedItems[0].SubItems[3].Text;
                    this.TextBox6.Text = this.ListView1.SelectedItems[0].SubItems[4].Text;
            }
    }
