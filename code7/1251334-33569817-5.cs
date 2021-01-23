    public ActionResult GetCaptions<T>() where T : TableBase
        {
            var set = db.Set<T>();
            // get all objects to array
            var list = set.OrderBy(i => i.CodeId).ToList();
            // serialize and return result
            // OR get single object and a value
            var item = set.FirstOrDefault();
            var propertyValue = item.Prop1;
        }
