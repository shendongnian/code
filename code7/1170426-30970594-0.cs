    public static List<Person> GetPeopleRange(int pageSize, int startIndex, int endIndex)
        {
            using (var db = new MyEntities())
            {
                return (from p in db.People
                        .Where(p => p.Id >= startIndex && p.Id < endIndex)
                            select p).Take(pageSize).OrderByDescending(p => p.Id).ToList();
            }
        }
