    public void RemoveWithRelatedEntries(int table1ItemID)
    {
        using(var db = new dbEntities())
        {
            // get all entities of table 2
            var tab2Entities = db.table2.Where(tab2Ent=>tab2Ent.table1Reference == table1ItemID);
            // remove all those entities
            foreach(table2Item item in tab2Entities)
            {            
                db.table2.Remove(item);
            }
            // finally remove entity from table 1
            var table1entitiy = db.table1.Find(table1ItemID);
            db.table1.Remove(table1entity);
            db.Save();
        }
    }
