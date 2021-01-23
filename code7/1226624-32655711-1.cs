     while(studentsByName.Any())
     {
         var uniqueStudents = new List<Student>();
         foreach(var name in studentsByName.Keys)
         {
             uniqueStudents.Add(studentsByName[name].Last());
             studentsByName[name].RemoveAt(studentsByName[name].Count -1);
             if(studentsByName[name].Count == 0)
             {
                 studentsByName.Remove(name);
             }
         }
         SaveListOfUniqueStudents(uniqueStudents);
     }
