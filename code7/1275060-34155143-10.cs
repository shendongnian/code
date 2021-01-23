        static void GetName(StudentDetails[]Student,  ref string[] parts)
        {
            for (int i = 0; i < Student.Length; i++ )
            {
                Student[i].name = parts[0];
                Student[i].surname = parts[1];
            }
        }
