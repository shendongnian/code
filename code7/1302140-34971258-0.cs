    private void FrmMain_Load(object sender, EventArgs e)
    {
        //you would fill from your file... this is just an example
        List<Student> students = new List<Student>();
    
        students.Add(new Student() { FirstName = "Joe", Gender = "Male" });
        students.Add(new Student() { FirstName = "Karen", Gender = "Female" });
    
        listBox.DataSource = students;
        listBox.DisplayMember = "FirstName";
    }
    
    public class Student
    {
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string DisplayString { get { return string.Format("Name of student: {0}\r\nGender: ({1})", FirstName, Gender); } }
    }
    
    private void listBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        Student selectedStudent = (Student)listBox.SelectedItem;
        MessageBox.Show(selectedStudent.DisplayString);
    }
