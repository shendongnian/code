    foreach (var inspection in inspections)
    {
        if (typeof (IParseTreeInspection).IsAssignableFrom(inspection))
        {
            var binding = Bind<IParseTreeInspection>()
                .To(inspection)
                .InSingletonScope()
                .Named(inspection.FullName);
            binding.Intercept().With<TimedCallLoggerInterceptor>();
            binding.Intercept().With<EnumerableCounterInterceptor<InspectionResultBase>>();
                    
            Bind<IInspection>().ToMethod(
                c => c.Kernel.Get<IParseTreeInspection>(inspection.FullName));
        }
        else
        {
            var binding = Bind<IInspection>().To(inspection).InSingletonScope();
            binding.Intercept().With<TimedCallLoggerInterceptor>();
            binding.Intercept().With<EnumerableCounterInterceptor<InspectionResultBase>>();
        }
    }
