    GlobalConfiguration.Configuration
        .EnableSwagger(c => {
        
            c.GroupActionsBy(apiDesc => {
                var attr = apiDesc
                    .GetControllerAndActionAttributes<DisplayNameAttribute>()
                    .FirstOrDefault();
                    
                // use controller name if the attribute isn't specified
                return attr?.DisplayName ?? apiDesc.ControllerName(); 
            });
            
        })
        .EnableSwaggerUi(c => {
            // your UI config here
        });
