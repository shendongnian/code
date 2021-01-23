      class Program
    {
        static void Main(string[] args)
        {
            using (var db = new aaContext2())
            {
                Temp temp = new Temp();
                var cc = db.Catagory.FirstOrDefault();
                IList<Category> parentList =new List <Category>();
                foreach (Category catagory in db.Catagory.Where(cat => cat.ParentId == null))
                {
                    parentList.Add(temp.Recursive(catagory.Id, catagory.Name));
                }
            }
        }
    }
    public class Temp{
        public Category Recursive(long parentId, string name)
        {
            Category catagory = new Category();
            catagory.Id = parentId; catagory.Name = name;
            using (var db = new aaContext2())
            {
                //base condition
                if (db.Catagory.Where(catagory1 => catagory1.ParentId == parentId).Count() < 1)
                {
                    return catagory;
                }
                else
                {
                    IList<Category> newCatagoryList = new List<Category>();
                    foreach (Category cat in db.Catagory.Where(cata => cata.ParentId == parentId))
                    {
                        newCatagoryList.Add(Recursive(cat.Id, cat.Name));
                    }
                    catagory.CatagoryList = newCatagoryList;
                    return catagory;
                }
            }
        }
    }
    public class aaContext2 : DbContext
    {
        public DbSet<Category> Catagory { get; set; }
    }
    public class Category
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> CatagoryList { get; set; }
        public virtual long? ParentId { get; set; }
    }
