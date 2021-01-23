    var octx = ((IObjectContextAdapter)ctx).ObjectContext; // ctx is regular DbContext here
    octx.ObjectStateManager.ObjectStateManagerChanged += (sender, item) =>
       {
           if (item.Action == CollectionChangeAction.Add) {
               // added
               var target = item.Element; // this is added entity
           }
       };
