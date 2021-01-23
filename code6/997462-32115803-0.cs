       protected static async Task<int> SaveEntity<t>(t obj) where t : BaseModel
        {
            try
            {
                using (DatabaseContext db = GetDbContext())
                {
                    //get the basemodel/fk reference properties
                    IEnumerable<PropertyInfo> props = obj.GetType().GetProperties().Where(p => p.PropertyType.BaseType == typeof(BaseModel));
                    if (obj.Id <= 0)
                    {//insert
                        db.Entry(obj).State = EntityState.Added;
                        //set fk reference props to unchanged state
                        foreach (PropertyInfo prop in props)
                        {
                            Object val = prop.GetValue(obj);
                            if (val != null)
                            {
                                db.Entry(val).State = EntityState.Unchanged;
                            }
                        }
                        //do insert
                        return await db.SaveChangesAsync();
                    }
                    else
                    {//update
                        //get the posted fk values, and set them to null on the obj (to avaid dbContext conflicts)
                        Dictionary<string, int?> updateFKValues = new Dictionary<string, int?>();
                        foreach (PropertyInfo prop in props)
                        {
                            BaseModel val = (BaseModel)prop.GetValue(obj);
                            if (val == null)
                            {
                                updateFKValues.Add(prop.Name, null);
                            }
                            else
                            {
                                updateFKValues.Add(prop.Name, val.Id);
                            }
                            prop.SetValue(obj, null);
                        }
                        //dbContext creation may need to move to here as per below working example
                        t dbObj = (t)db.Set(typeof(t)).Find(new object[] { obj.Id }); //this also differs from example
                        //update the simple values
                        db.Entry(dbObj).CurrentValues.SetValues(obj);
                        //update complex values
                        foreach (PropertyInfo prop in props)
                        {
                            Object propValue = null;
                            if (updateFKValues[prop.Name].HasValue)
                            {
                                propValue = (BaseModel)db.Set(prop.PropertyType).Find(new object[] { updateFKValues[prop.Name] });
                            }
                            prop.SetValue(dbObj, propValue);
                            if (propValue != null)
                            {
                                db.Entry(propValue).State = EntityState.Unchanged;
                            }
                        }
                        //do update
                        return await db.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.Log(ex);
                throw;
            }
        }
