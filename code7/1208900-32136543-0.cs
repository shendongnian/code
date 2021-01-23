    public List<Checklist> Provide()
    {
      List<Checklist> checklists = new List<Checklist>();
      using (var reader = ExcelReaderFactory.CreateOpenXmlReader(m_Stream))
       {
                    while (reader.Read())
                    {
                        Checklist checklist = new Checklist();
                         checklist.Description = reader.GetString(1);
                         checklist.View = reader.GetString(2);
                         checklist.Organ = reader.GetString(3);
                         checklists.Add(checklist);
                     }
                    return checklists; 
        }
    }
           
