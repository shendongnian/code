     private gigadeEntities1 db = new gigadeEntities1();
     public IQueryable GetAll(string id)
            {
                switch(id)
                {
                    case "travel":
                        return db.travel;
                    case "announce":
                        return db.announce;
                }
    
                return null;
            }
