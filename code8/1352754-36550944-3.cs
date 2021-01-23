    //In Linq to Entities you can project to using an anonymous type or a custom class(also known as a DTO)
    var cars= context.Cars
                     .Include("Owner")
                     .Include("Parts")
                     .Where(c=>c.id == strID)
                     .Select(c=>new {//Change this projection at your convinience
                                     Car=c, 
                                     Parts= c.Parts.OrderBy(p=>p.PartName), 
                                     Owner=p.Owner
                                    });
