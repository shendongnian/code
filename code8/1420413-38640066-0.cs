    public IEnumerable<inventoryTypeModel> getInventoryTypes()
    {
     var _type = dbgpsContext.InventoryType.Where(d=> d.ParentId == null).Select(b => new
                  {
                    Typeid = b.InventoryTypeId  ,
                    Type = b.Type,
                    Subtypes = dbgpsContext.InventoryType.Where(v=> v.ParentId == b.Id).Select(c => c.Type)
                    }).ToList();
     return _type; 
    }
