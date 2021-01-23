    openFileDialog1.ShowDialog();
    string file = openFileDialog1.FileName;
    StreamReader sr = new StreamReader(file);
    string line = "";
    while ((line = sr.ReadLine()) != null)
    { 
        studentList.Items.Add(line);
        string name = "";
        string gender = "";
    
        char[] selected = line.ToCharArray();
        for (int i = 0; i < selected.Length; i++)
        {
            if (selected[i] != '(')
            {
                name += selected[i];
            }
            else if (selected[i] == '(')
            {
                gender += selected[i + 1];
                break;
            }
            
        }
        Student student = new Student();
        student.setName(name);
        student.setGender(gender);
        list.addStudent(student);
    }
