    public static class MyRegistrationExtensions 
    {
        public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle>
            AsWebApiAuthorizationFilterFor(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Type controllerType)
        {
            return AsFilterFor<IAutofacAuthorizationFilter>(registration, AutofacWebApiFilterProvider.AuthorizationFilterMetadataKey, controllerType);
        }
        static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle>
            AsFilterFor<TFilter>(IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, string metadataKey, Type controllerType)
        {
            if (registration == null) throw new ArgumentNullException("registration");
            if (controllerType == null) throw new ArgumentNullException("controllerType");
            if (!controllerType.IsAssignableTo<IHttpController>()) throw new ArgumentNullException("controllerType");
            var limitType = registration.ActivatorData.Activator.LimitType;
            if (!limitType.IsAssignableTo<TFilter>())
            {
                var message = string.Format(CultureInfo.CurrentCulture, RegistrationExtensionsResources.MustBeAssignableToFilterType,
                    limitType.FullName, typeof(TFilter).FullName);
                throw new ArgumentException(message, "registration");
            }
            var metadata = new FilterMetadata
            {
                ControllerType = controllerType,
                FilterScope = FilterScope.Controller,
                MethodInfo = null
            };
            return registration.As<TFilter>().WithMetadata(metadataKey, metadata);
        }
    }
