            var module = new DependencyTrackingTelemetryModule();
            module.Initialize(configuration);
            QuickPulseTelemetryProcessor processor = null;
            configuration.TelemetryProcessorChainBuilder
                .Use(next =>
                {
                    processor = new QuickPulseTelemetryProcessor(next);
                    return processor;
                })
                .Build();
            var quickPulse = new QuickPulseTelemetryModule();
            quickPulse.Initialize(configuration);
            quickPulse.RegisterTelemetryProcessor(processor);
