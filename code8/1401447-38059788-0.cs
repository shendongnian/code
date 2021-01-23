    var entityDescriptorType = typeof (EntityDescriptor);
    //using .Assembly.GetType() on a type known to be in the right assembly
    //is a fast way to get nonpublic types by fullname
    var clientEdmModelType = entityDescriptorType.Assembly.GetType("System.Data.Services.Client.ClientEdmModel");
    var clientEdmModelCtorArgs = new object[] {DataServiceProtocolVersion.V1};
    var clientEdmModelCtor = clientEdmModelType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
        null, new[] {typeof (DataServiceProtocolVersion)}, null);
    var clientEdmModelInstance = clientEdmModelCtor.Invoke(clientEdmModelCtorArgs);
    var entityDescriptorCtorArgs = new[] {clientEdmModelInstance};
    var entityDescriptorCtor = entityDescriptorType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
        null, new[] {clientEdmModelType}, null);
    var entityDescriptorInstance = entityDescriptorCtor.Invoke(entityDescriptorCtorArgs);
