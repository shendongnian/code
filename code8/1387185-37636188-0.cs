    using (var db = new Db())
                {
                    Record newdt = new Record { Value = 1000, Date = new System.DateTime(2016, 8, 30, 0, 0, 0, DateTimeKind.Local) };
                    Record newdtUtc = new Record { Value = 2000, Date = new System.DateTime(2016, 8, 30, 0, 0, 0, DateTimeKind.Utc) };
                    db.Insert(newdt);
                    db.Insert(newdtUtc);
