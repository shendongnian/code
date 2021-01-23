    Data data = new Data();
    Models.DataModel someDBContext = new Models.DataModel();
    
    data.Name = "John";
    data.Job = "Technician";
    
    var fullList = from item in someDbContext.Items
                        select item;
    
    foreach (var item in fullList){
           if(item.Name.Trim() == data.Name && item.Job == data.Job)
              {
               someDBContext.Items.Add(item);
              }
    }
    someDbContext.SaveChanges();
