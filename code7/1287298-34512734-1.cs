    static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle>
        AsFilterFor<TFilter, TController>(IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, string metadataKey)
            where TController : IHttpController
    {
        if (registration == null) throw new ArgumentNullException("registration");
        var limitType = registration.ActivatorData.Activator.LimitType;
        if (!limitType.IsAssignableTo<TFilter>())
        {
            var message = string.Format(CultureInfo.CurrentCulture, RegistrationExtensionsResources.MustBeAssignableToFilterType,
                limitType.FullName, typeof(TFilter).FullName);
            throw new ArgumentException(message, "registration");
        }
        var metadata = new FilterMetadata
        {
            ControllerType = typeof(TController),
            FilterScope = FilterScope.Controller,
            MethodInfo = null
        };
        return registration.As<TFilter>().WithMetadata(metadataKey, metadata);
    }
