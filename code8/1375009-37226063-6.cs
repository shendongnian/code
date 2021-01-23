    public string text1;
    public string text2;
    public string text3;
    private void button1_Click(object sender, EventArgs e)
        {
            this.text1 = this.textBox1.Text;
            this.text2 = this.textBox2.Text;
            this.text3 = this.textBox3.Text;
            DemandePrixFournisseur dpf = new DemandePrixFournisseur(this);
            dpf.Show();
            this.Hide();
        }
