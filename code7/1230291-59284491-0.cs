    private void FormPeople_Load(object sender, EventArgs e)
        {
            populateComboBoxTitles();
    }
    public void populateComboBoxTitles()
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("mr");
                 comboBox2.Items.Add("miss");
            
    }
    private void button5_Click(object sender, EventArgs e)
        {
    FormAddTitle formAddTitle = new FormAddTitle(this);
            formAddTitle.Show();
    }
