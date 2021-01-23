     while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                if(columns.length>=2)
                {
                Assignment assignment = new Assignment();
    
                assignment.Employee.Name = columns[0];
                assignment.Request.Name = columns[1];
                assignments.Add(assignment);
               }
            }
