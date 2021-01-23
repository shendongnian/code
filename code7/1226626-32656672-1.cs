        IEnumerable<IEnumerable<Student>> Process(IEnumerable<Student> students)
        {
            var files = new List<Dictionary<string, Student>>();
            foreach (var student in students)
            {
                var isAdded = false;
                foreach (var file in files)
                {
                    if (!file.ContainsKey(student.Name))
                    {
                        file.Add(student.Name, student);
                        isAdded = true;
                        break;
                    }
                }
                if (!isAdded)
                {
                    files.Add(new Dictionary<string, Student>
                    {
                        { student.Name, student }
                    });
                }
            }
            return files.Select(kvp => kvp.Values);
        }
