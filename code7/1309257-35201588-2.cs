    public class ModelService {
        public void Edit(IPrincipal user, SetValue setValue){
            setValue.Value = valuestring;
                var original = db.SetValue.Find(setValue.SetValueID);
                bool modified = original.Value != setValue.Value;
                if (modified)
                {
                    var rev = new RevisionHistory();
                    rev.CreatedOn = original.ModifiedOn;
                    rev.ModifiedBy = User.Identity.Name; //If modified exception on this line
                    db.Entry(original).CurrentValues.SetValues(setValue);
                    db.RevisionHistory.Add(rev);
                }
                original.ModifiedOn = DateTime.Now;
                original.ModifiedBy = User.Identity.Name; //if not modified exception on this line
                db.Entry(original).State = EntityState.Modified; 
                db.SaveChanges();
        }
    }
