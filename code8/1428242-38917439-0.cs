        class Problem{
            public Problem(data, Func<data, IEnumerable<Class1>> delegate){
                  ReturnedData = delegate(data);
            }
         }
    
    var problem = new Problem(data, ds => ds.where(d => d.name =="xyz").tolist());
