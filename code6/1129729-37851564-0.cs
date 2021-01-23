              List<ISSUES> list = new List<ISSUES>();
              using (FTUEntities1 db = new FTUEntities1())
              {
                  list = db.ISSUES.Include(a => a.CLIENTS).ToList();
                  return list;
              }
          }
