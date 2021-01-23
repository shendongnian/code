    dynamic entityOrgModule;
                using (var context = new MIHR.Business.EF.SA_MIHR_DEVEntities())
                {
                    entityOrgModule = (from c in context.EntityOrgModule
                                       join p in context.MemberEomMapping on c.Id equals p.EomId into gj
                                       from x in gj.DefaultIfEmpty()
                                       where c.EntityType == UserEntityTypeId && c.EntityId == UserEntityId && c.Rowstatus == 1 && c.EOMTYPEID == 116002 && mylist.Any(y => y == c.ParentId) 
                                       select new
                                       {
                                           c.Id,
                                           c.Name,
                                           c.ParentId,
                                           isSelected = (x == null ? false : true)
                                       }).ToList();
                }
