    Entities dbPOEntity = new Entities(); //Entities is an auto generated class that extends dbContext 
        
    List<Space> lsSpace = dbPOEntity.Spaces
    .Where(sp =>   sp.Name.Contains(word+" ")
                 ||sp.Name.Conteins(" "+word)).OrderBy(sp => sp.Name).ToList();
