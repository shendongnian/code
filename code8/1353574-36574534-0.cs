    public IEnumerable<model.Contact> Execute(GetContactById parameters)
    {
         IEnumerable<model.Contact> ContactsById = null;
         DbRetryHandler.RetryHandler(delegate(DeviceModelContext retryContext)
         {
             var parametersId = parameters.Id; // <-- store id in variable
             camerasByDeviceId = retryContext.Contact
               .Where(c => c.Id == parametersId) // <-- use == instead of Equals
               .Select(c => new model.Camera
               {
                   // unrelated code
               });
         });
    
         return ContactsById;
    }
