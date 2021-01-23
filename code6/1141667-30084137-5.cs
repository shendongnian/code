        static FamilyNamespace.IFamily GetDecorator(Domain.Parent item)
        {
          var baseType = item.GetType();
          var derivedType = Assembly.GetExecutingAssembly().GetTypes().Where(m => m != baseType && baseType.IsAssignableFrom(m));
          if (derivedType.Any())
          {
            return (FamilyNamespace.IFamily)Activator.CreateInstance(derivedType.First(), new object[] { item });
          }
          return null;
        }
