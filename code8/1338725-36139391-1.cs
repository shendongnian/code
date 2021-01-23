    public List<info> Getdetails(string name)
             {
                 List<info> lst = new List<info>();
                 DataClasses1DataContext con = new DataClasses1DataContext();
                 var res = (from c in con.Datavalues
                           join d in con.Details on c.Roll_no equals d.Roll_number
                           where c.Name == name
                           select new info() { c.Name, c.Age, c.Address, c.Roll_no, d.Section }).ToList();
                 foreach (var r in res)
                 {
                     info info= new info();
                     Roll roll1 =new Roll();
                     roll1.Roll_number=Convert.ToInt32(r.Roll_no);
                     roll1.Section = r.Section;
                     info.address = r.Address;
                     info.age = Convert.ToInt32(r.Age);
                     info.name = r.Name;
                     info.roll = roll1;
                     lst.Add(info);
    
    
    
                 }
                 return lst;
    
    
             }
