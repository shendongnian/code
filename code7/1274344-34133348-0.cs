     public void updateMultiple()
            {
                var ls = new int[] { 2, 3, 4 };
                var name = "xyz";
                using (var db = new SomeDatabaseContext())
                {
                    var some = db.SomeTable.Where(x => ls.Contains(x.friendid)).ToList();
                    some.ForEach(a =>
                                    {
                                        a.status = true;
                                        a.name = name;
                                    }
                                );
                    db.SubmitChanges();
                }
            }
