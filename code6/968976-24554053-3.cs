           Type attributeType = typeof(WorkerAttribute);
            var myWorkerClassesPlusAttributes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                                from type in assembly.GetTypes()
                                                let attributes = type.GetCustomAttributes(attributeType, true)
                                                where attributes.Any()
                                                select 
                                                    new KeyValuePair<String, Type>(((WorkerAttribute)attributes.First()).OperationType, 
                                                                                   type);
            Dictionary<String, Type> workers = new Dictionary<string, Type>();
            foreach (var item in myWorkerClassesPlusAttributes)
                workers.Add(item.Key, item.Value);
            IWorker worker = (IWorker)Activator.CreateInstance(workers["Experienced"]);
        
