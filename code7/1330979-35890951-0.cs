        private void Form1_Load(object sender, EventArgs e)
        {
            List<Student> allStudent = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                allStudent.Add(new Student { Name = "Student" + i, Roll = i + 1 });
            }
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = allStudent;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }
        public partial class Student
        {
            public string Name { get; set; }
            public int Roll { get; set; }
        }
