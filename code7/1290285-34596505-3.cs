        public IRepository<TEntity> GetRepository<TEntity>(FormTypes formType) where TEntity: class, IEntity
        {
            // Represents the IRepository that should be created, based on the form type passed
            var typeToCreate = formType.GetAttribute<EnumTypeAttribute>().Type;
            // return an instance of the form type repository
            IRepository<TEntity> type = Activator.CreateInstance(typeToCreate) as IRepository<TEntity>;
            if (type != null)
                return type;
            throw new ArgumentException(string.Format("No repository found for {0}", nameof(formType)));
        }
    }
