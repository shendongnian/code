    var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser("<file path>");
            parser.SetFieldWidths(4, 4, 12, 8, 2);
            while (!parser.EndOfData)
            {
                string[] line = parser.ReadFields();
                var student = new Student();
                student.Year = int.Parse(line[0]);
                student.Class = int.Parse(line[1]);
                student.Name = line[2].Trim();
                student.Surname = line[3].Trim();
                student.Average = int.Parse(line[4]);
            }
