    SetConfig(new HostConfig { 
        MapExceptionToStatusCode = {
            { typeof(CustomInvalidRoleException), 403 },
            { typeof(CustomerNotFoundException), 404 },
        }
    });
