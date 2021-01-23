        private static void AddSingletonInstance<T>(ContainerBuilder builder, Assembly[] assembliesToRegister, string typeName)
        {
            var singletonType = (from asm in assembliesToRegister
                            from tt in asm.DefinedTypes
                            where tt.Name == typeName
                            select tt).FirstOrDefault();
            if (singletonType != null)
                builder.RegisterType(singletonType).As<T>().SingleInstance().ExternallyOwned();
        }
