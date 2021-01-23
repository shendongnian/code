    @{
        var properties = Model.GetType().GetProperties();
    }
    
    @foreach(System.Reflection.PropertyInfo info in properties){
       var value = info.GetValue(Model,null);
       if(value!=null){
           <b>@info.Name</b> <i>@value</i>
       }
    }
