    if (modelType .GetGenericArguments()[0].IsAssignableFrom(typeof(IRequestFromResponse)) && 
        modelType.GetGenericTypeDefinition().IsAssignableFrom(typeof(BaseRequestWrapperResponse<>)) 
        {
            model = ((BaseRequestWrapperResponse<IRequestFromResponse>) model).Request;
        }
