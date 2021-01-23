    public static void PublishTable<TEntity>()
            {
                var targetEntity = typeof(TEntity).Name;
                var model = JsonConvert.DeserializeObject<Models.FullDataSetModel>(DataAccess.GetEnvironmentJson((int)Environments.Production));
                using (var db = new LoginPageContentEntities())
                {
                    var deployEntry = db.Deployment.Find((int)Environments.Production);
                    deployEntry.DateUpdated = DateTime.Now;
                    deployEntry.GetType().GetProperty(targetEntity).SetValue(deployEntry, false);
                    model.GetType().GetProperty(targetEntity).SetValue(model, ((IEnumerable<TEntity>)(typeof(LoginPageContentEntities).GetProperty(targetEntity).GetValue(db, null))).ToList());
                    deployEntry.JsonCache = JsonConvert.SerializeObject(model);
                    db.SaveChanges();
                }
            }
