    _context.TableC.Select(x => x.TableB)
       .Select(x => new CustomTable
          {
             tableDesc = x.TableC.Desc,
             tableBDesc = x.Desc
          });
