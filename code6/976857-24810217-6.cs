    class Program
    {
        static void Main(string[] args)
        {
            MyContext db = null; ;
            try
            {
                db = new MyContext();
                Foo(db);
                Console.WriteLine("Id\tDate\tName");
                foreach(var c in db.MyClasses)
                {
                    Console.WriteLine("{0}\t{1}\t{2}",c.IdMyClass,c.ModificationDate,c.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
            Console.ReadLine();
        
        }
        static void Foo(MyContext db)
        {
            var sampleModel = new MyClass();
            sampleModel.IdMyClass = "1d1ba1f2-8c08-c334-5486-08d16fecc6e3"; //GUID
            sampleModel.ModificationDate = DateTime.Now;
            sampleModel.Name = string.Empty; //should not be needed
            db.MyClasses.Attach(sampleModel);
            var entry = db.Entry(sampleModel);
            entry.State = EntityState.Modified;
            var excluded = new string[] { "Name" };
            foreach (var name in excluded)
            {
                entry.Property(name).IsModified = false;
            }
            db.SaveChanges();
        }
    }
