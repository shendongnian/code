       public ActionResult Sortstock(string sort= "", string sortdir="")
       {
           List<Item> stocks = Student.getStock();
           IQueryable<Item> stud = SortIQueryable<Item>(Student.getStock().AsQueryable(), sort, sortdir);
           return View(stud);
       }
 
        public static IQueryable<T> SortIQueryable<T>(IQueryable<T> data, string fieldName, string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(fieldName)) return data;
            if (string.IsNullOrWhiteSpace(sortOrder)) return data;
 
            var param = Expression.Parameter(typeof(T), "i");
            Expression conversion = Expression.Convert(Expression.Property(param, fieldName), typeof(object));
            var mySortExpression = Expression.Lambda<Func<T, object>>(conversion, param);
 
            return (sortOrder == "desc") ? data.OrderByDescending(mySortExpression) : data.OrderBy(mySortExpression);
        }
