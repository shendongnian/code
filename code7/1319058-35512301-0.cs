    public class MyController : ApiController
    {
     public object SomeGetAction()
     {
       var model1 = GetModel1();
       if (android)
       {
        // send back partial payload
        return new { field1 = model1.field1, field3 = model1.field3 }; 
       }
  
       // for clients needing full payload.
       return model1;
     }
    }
