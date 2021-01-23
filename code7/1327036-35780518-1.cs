            public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
            {
                if (bindingContext.ModelType == typeof(MyComplexType))
                {
                    MyComplexType model ;
                    
                    var theValue = bindingContext.ValueProvider.GetValue ( bindingContext.ModelName);
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
 
