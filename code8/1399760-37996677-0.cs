    var query = (from ta in ef.TableA
                 where (from tb in ef.TableB
                        from tc in ef.TableC
                            .Where(tc => tc.ID == tb.fkC)
                        select new { NewNames = tb.StringField ?? SqlFunctions.StringConvert((double)tc.IntField) + SqlFunctions.StringConvert((double)tb.IntField2)}
                        ).Any(e.NewNames==ta.Filename)
                 select ta.Filename
                ).Distinct().OrderBy(ta => ta.Filename).ToList();
