    [HttpPost]
        [ValidateAntiForgeryToken]
        public string Edit(int Id, string Key, string Value)
        {
            Article Article = Db.ArticleById(Id);
            if (Key.Contains(".")) //Property is a custom class
            {
                string[] Keys = Key.Split('.');
                PropertyInfo prop = Article.GetType().GetProperty(Keys[0]);
                Type type = prop.PropertyType;
                object propInstance = Db.Object(type, Convert.ToInt32(Value)); // See the code of this method below
                prop.SetValue(Article, propInstance);
                Db.Update(ref Article);
            }
            else // Property is a simple type: string, int, double, dattime etc.
            {
                PropertyInfo prop = Article.GetType().GetProperty(Key);
                prop.SetValue(Article, Convert.ChangeType(Value, prop.PropertyType), null);
                Db.Update(ref Article);
            }
            Db.Save();
            return Value;
        }
     public static object Object(Type type, int Id)
        {
            object Obj = Ctx.Set(type).Find(Id); //Ctx is may entityFramework Context
            return Obj;
        }
