                Boolean found = false;
                foreach (Student student in students)
                //(int i = 0; i < students.Count; i++)
                {
                    if (student.Name.Contains(studentNameSearch))
                    {
                        Console.WriteLine(student.ToString());
                        found = true;
                        break;
                    }
                }
                if(found == false)
                {
                        Console.WriteLine("Student name not found");
                }​
