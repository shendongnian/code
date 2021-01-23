    public partial class MyWindow
    {
        BindingList<Data_Type> list = new BindingList<Data_Type>();
        private void Display_Load(object sender, EventArgs e)
        {
            string str = "SELECT i_id, i_name FROM sales";
            comboBox1.DataSource = getData(str);
            comboBox1.DisplayMember = "i_name";
            comboBox1.ValueMember = "i_id";
            dataGridView1.DataSource = list;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val;
            Int32.TryParse(comboBox1.SelectedValue.ToString(), out val);
            string str = "SELECT i_id, i_name, qty, rate,discount  FROM sales WHERE i_id = " + val;
            var newData = getData(str);
            foreach (var line in newData)
            {
                list.Add(line);
            }
        }
    }
