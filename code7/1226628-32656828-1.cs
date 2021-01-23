    IEnumerable<Student> LoadStudentsFromFile(string path)
    {
      return File.ReadLines(path).Select(x=>{
        var fields=x.Split(','); 
        return new Student {Name=fields[0],Id=field[1]});
    }
    void SaveStudentsToFile(path,IEnumerable<Student> students)
    {
      File.WriteAllLines(path,students);
    }
    var students=LoadStudentsFromFile("inputfile.csv");
    var studentsByName = students.GroupBy(st => st.Name)
      .ToDictionary(g => g.Key, g => g.ToList());
    var max=studentsByName.Max(x=>x.Value.Count());
    for(var x=0;x<max;x++)
      SaveStudentsToFile("outfile"+x+".csv",
        studentsByName.Where(s=>s.Value.Count()>=x+1)
          .Select(s=>string.Format("{0},{1}",s.Key,s.Value.Skip(x).First)));
   
