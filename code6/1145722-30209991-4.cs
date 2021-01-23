        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterType<MyPage>().OnActivating(e =>
        {
            foreach (PropertyInfo pi in e.Instance.GetType()
                                                    .GetProperties()
                                                    .Where(pi => pi.CanWrite))
            {
                if (!pi.PropertyType.IsClosedTypeOf(typeof(IList<>)))
                {
                    Object propertyValue = e.Context.ResolveOptional(pi.PropertyType);
                    if (propertyValue != null)
                    {
                        pi.SetValue(e.Instance, propertyValue);
                    }
                }
            }
        });
