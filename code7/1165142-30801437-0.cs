               if (model.Id != model.ParentId)
               {
                   data.Description = model.Description;
                   data.Name = model.Name;
                   data.LastChangeDate = DateTime.Now;
                   data.Slug = model.Slug;
                   data.Status = model.Status;
                   data.CreatedDates = DateTime.Now;
                   data.Id = model.Id;
                   if (model.ParentId == 0)
                   {
                     **data.Category1.ParentId = null;**
                   }
                   else
                   {
                       data.Category1 = (from p in objContext.Categories where p.Id == model.ParentId select p).SingleOrDefault();
                   }
                   objContext.SaveChanges();
                   return UserFriendlyMessage.CategoryUpdate;
               }
