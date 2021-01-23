    @model List<Task>
    @if(Model.Any())
    {
       var propArr = Model.Events[0].GetType().GetProperties();
       foreach (var ev in Model)
       {
          var p = ev.GetType().GetProperties();
          foreach (var propertyInfo in propArr)
          {
             <h4>@propertyInfo.Name</h4>     
             var val = propertyInfo.GetValue(ev, null);
             if (val != null)
             {
                 <p>@val</p>
             }
          }        
        }
    }
