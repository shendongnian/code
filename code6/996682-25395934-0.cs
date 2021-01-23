       public virtual TPoco Get(Expression<Func<TPoco, bool>> predicate) {
            try {
                var resultEntity = AllQ().FirstOrDefault(predicate);  //<<<<< Breakpoint, predicate can be viewed
                return resultEntity;
            }
            catch (Exception ex) {
                // your error handling             
                return null;
            }
        }
        // call with 
        var rep = new Rep<Table>();
        var row = rep.Get(t=>t.StartsWith("o" );
