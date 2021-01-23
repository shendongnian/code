    public static List<string> GetNotAvailEmp(Entity1 entityx)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var x = db.MyEntity.Include(ds => ds.MyEntity1)
                    .Where(ds =>
                        (
                          ds.MyEntity1.MyEntity12.x <= entityx.MyEntity12.x
                            &&
                          ds.MyEntity1.MyEntity12.y>= entityx.MyEntity12.x
                        )
                        ||
                        (
                         ds.MyEntity1.MyEntity12.x<= entityx.MyEntity12.y
                           &&
                         ds.MyEntity1.MyEntity12.y>= entityx.MyEntity12.y
                        ))
                       .Select(ds => ds.Emp.EmpId).ToList();
                return x;
            }
        }
