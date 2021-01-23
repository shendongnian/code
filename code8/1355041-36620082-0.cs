    private void Form1_Load(object sender, EventArgs e)
            {
                List<Person> mypeople = new List<Person>();
                mypeople.Add(new Person() { Key = 3, Value = "Turgay" });
                mypeople.Add(new Person() { Key = 4, Value = "Hamsi" });
                mypeople.Add(new Person() { Key = 5, Value = "Cabbar" });
    
                dataGridView1.DataSource = mypeople;
    
    
                dataGridView1.MouseEnter += DataGridView1_MouseEnter;
                dataGridView1.MouseLeave += DataGridView1_MouseLeave;
            }
    
            private void DataGridView1_MouseEnter(object sender, EventArgs e)
            {
                InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
            }
    
            private void DataGridView1_MouseLeave(object sender, EventArgs e)
            {
                InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
            }
