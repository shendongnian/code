    public class Worker
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public static FromWorker(Worker worker)
        {
            // example of maping the entities... preferably not hardcoded like this
            return new Worker
            {
                ID = worker.ID,
                Name = worker.Name,
            };
        }
    
        public bool Save(MyDatabase db)
        {
            try
            {
                Worker worker = Worker.FromWorker(this);
                if (db.Workers.Any(w => w.ID == worker.ID))
                {
                    db.Workers.Attach(worker);
                    db.Entry(worker).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db.Workers.Add(worker);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
    
            return true;
        }
    }
