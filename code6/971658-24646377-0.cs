       public virtual IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
            {
                // Add check if controller is inheriteted from your application specific   base controller     
                //OR     
                // Controller is from your Application Assembly    
               //OR
               //You can add some custom logic to select list of controllers to skip here
                if (controllerContext.Controller != null)
                {
                    foreach (FilterAttribute attr in GetControllerAttributes(controllerContext, actionDescriptor))
                    {
                        yield return new Filter(attr, FilterScope.Controller, order: null);
                    }
                    foreach (FilterAttribute attr in GetActionAttributes(controllerContext, actionDescriptor))
                    {
                        yield return new Filter(attr, FilterScope.Action, order: null);
                    }
                }             
            }
