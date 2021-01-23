    var mapLambda = 
          /* you'll need to fix the typing here */(m) => 
          { 
               m.MapInheritedProperties();
               m.ToTable("CardPayments");
          };
    var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
    var entityResult = 
         entityMethod.MakeGenericMethod(type)
              .Invoke(modelBuilder, new object[] { });
 
    //invoke Map
    entityResult.GetType().GetMethod("Map").Invoke(entityResult, new object[]{ mapLambda });
     
