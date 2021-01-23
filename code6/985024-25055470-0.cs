    public virtual int EditObject(T objToEdit)
        {
            var curval = DB.Set<T>().FirstOrDefault(x => x.Id == objToEdit.Id);
            //You may want to make all your entities inherit from the same 
            //baseclass to get Id
            if (curval == null)
            {
                DB.Set<T>.Add(objToEdit);
            }
            else
            {
                DB.Entry(curval).CurrentValues.SetValues(objToEdit);
                DB.Entry(curval).State = System.Data.Entity.EntityState.Modified;
            }
            return DB.SaveChanges();
        }
