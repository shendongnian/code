     StringBuilder sb = new StringBuilder();
     foreach (var student in _StudentList)
     {
          sb.Append(Environment.NewLine + "Name: " + student.Name);
          sb.Append(Environment.NewLine + "Surname: " + student.Surname);
          sb.Append(Environment.NewLine + "Age: " + _Student.Age);
          sb.Append(Environment.NewLine + "Student Average: " + _Student.AverageMark);
          sb.Append(Environment.NewLine);
     }
     richTextBox1.Text = sb.ToString();
