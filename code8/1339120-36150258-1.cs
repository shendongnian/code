    var yourQuery = Context.STopics.AsQueryable(); 
    var yourParam = "ALL";
    if(yourParam != "ALL")
       yourQuery = yourQuery.Where(x => x.IsActive==true && x.StudentID == 123);
    
    var abc = yourQuery.Select(x=> new result()
                                   {
                                      name = st.name 
                                   }).ToList();
