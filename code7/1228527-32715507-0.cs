    using (var context = new CDataContext(_connectionString))
    {
        foreach (var cEntity in cEntities)
        {
            var entity = context.CEntities.FirstOrDefault(x => x.ServiceId == cEntity.ServiceId && x.TypeID == cEntity.TypeID && x.CKey == cEntity.CKey);
            if(entity == null)
                context.CEntities.Add(cEntity);
            else 
            {
                entity.CValue = cEntity.CValue;
                entity.CKey = cEntity.CKey;
            }
        }
        result = context.SaveChanges(); 
    }
