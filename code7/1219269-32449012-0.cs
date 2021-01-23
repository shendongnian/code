    ...    
    using (var db = new MyDbContext())
            {
                alt = db.AddressLineTypes.Single(x => x.Value == "TypeValue");
            
        
                al.AddressLineTypes.Add(alt);
                r.AddressLines.Add(al);
        
                SaveRecord(r, db);
            }
        }
    
    public void SaveRecord(Record r, MyDbContext db)
    {
            db.Records.Add(r);
            db.SaveChanges();
    }
