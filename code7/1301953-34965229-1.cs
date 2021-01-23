    string[] students = File.ReadAllLines(openFileDialog1.FileName);
    foreach (string student in students)
    {
        string[] split = student.Split('(');
        StudentList.Add(new Student() { Name = split[0], Gender = split[1][0].ToString() });
    }
    listBox1.Items.Clear();
    listBox1.Items.AddRange(StudentList.ToArray());
