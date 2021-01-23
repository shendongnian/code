    public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
    {
       if (bindingContext.ModelType == typeof(MyComplexType))
       {
          MyComplexType model ;
                    
          //You can use the value provider or get it from the HttpRequest
          //var theValue = bindingContext.ValueProvider.GetValue ( bindingContext.ModelName);
          //var theValue = request.RequestUri.ParseQueryString ( ) ;
          if ( new MyComplexTypeConverter( ).TryParse ( actionContext.Request, out model) )
          { 
             bindingContext.Model = model;
                   
             return true;
          }
          else
          { 
             bindingContext.ModelState.AddModelError( bindingContext.ModelName, "Cannot convert request to MyComplexType");
    
             return false;
          }
       }
    
       return false ;
    }
 
