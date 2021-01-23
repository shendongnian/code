     foreach (var dri in getStudentList)
                    {
         this.StudentListItems.Add(new StudentListModel()
                                {
                                    Id= dri.Id,
                                    Name= dri.Name,
                                    Contact= dri.Contact,
                                    Email=  dri.Email,
            
                                });
    }
