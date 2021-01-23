                //register all pre handlers
                builder.RegisterAssemblyTypes(assembliesToScan)
                    .AsClosedTypesOf(typeof(IAsyncPreRequestHandler<>));
    
                //register all post handlers
                builder.RegisterAssemblyTypes(assembliesToScan)
                    .AsClosedTypesOf(typeof(IAsyncPostRequestHandler<,>));
    
                const string handlerKey = "async-service-handlers";
                const string pipelineKey = "async-service-pipelines";
    
                // Request/Response for Query
    
                builder.RegisterAssemblyTypes(assembliesToScan)
                    .AsKeyedClosedTypesOf(typeof(IAsyncRequestHandler<,>), handlerKey)
                    ;
    
                // Decorate All Services with our Pipeline
                //builder.RegisterGenericDecorator(typeof(MediatorPipeline<,>), typeof(IRequestHandler<,>), fromKey: "service-handlers", toKey: "pipeline-handlers");
               builder.RegisterGenericDecorator(typeof(AsyncMediatorPipeline<,>), typeof(IAsyncRequestHandler<,>), fromKey: handlerKey, toKey: pipelineKey);
    
                // Decorate All Pipelines with our Validator
               builder.RegisterGenericDecorator(typeof(AsyncValidationHandler<,>), typeof(IAsyncRequestHandler<,>), fromKey: pipelineKey);//, toKey: "async-validator-handlers");
               // Add as many pipelines as you want, but the to/from keys must be kept in order and unique
