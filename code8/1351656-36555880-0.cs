        public override Object Instantiate(String clazz, EntityMode entityMode, Object id)
        {
            if (entityMode == EntityMode.Poco)
            {
                Type type = Type.GetType(clazz, false);
                if (type != null)
                {
                    Object instance = CreateProxy(type);
                    this.session.SessionFactory.GetClassMetadata(clazz).SetIdentifier(instance, id, entityMode);
                    return (instance);
                }
            }
            return (base.Instantiate(clazz, entityMode, id));
        }
        public static Object CreateProxy(Type type)
        {
            List<Type> interfaces = new List<Type>();
            //TODO: add interfaces to list
            interfaces.Add(typeof(IBar));
            Object instance = null;
            if ((interfaces.Count != 0) && (type.IsSealed == false))
            {
                //TODO: pass any custom parameters to the _CustomInterceptor class
                instance = proxyGenerator.CreateProxy(type, new CustomPictureInterceptor(), interfaces.ToArray());
            }
            else
            {
                instance = Activator.CreateInstance(type);
            }
            return (instance);
        }
