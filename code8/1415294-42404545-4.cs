	public static class EntityTypeConfigurationExtensions
	{
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, byte[]>> propertyExpression,
			Func<BinaryPropertyConfiguration, BinaryPropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, Guid>> propertyExpression,
			Func<PrimitivePropertyConfiguration, PrimitivePropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, Guid?>> propertyExpression,
			Func<PrimitivePropertyConfiguration, PrimitivePropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, TimeSpan?>> propertyExpression,
			Func<DateTimePropertyConfiguration, DateTimePropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, TimeSpan>> propertyExpression,
			Func<DateTimePropertyConfiguration, DateTimePropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, DateTimeOffset?>> propertyExpression,
			Func<DateTimePropertyConfiguration, DateTimePropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, DateTimeOffset>> propertyExpression,
			Func<DateTimePropertyConfiguration, DateTimePropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, DateTime?>> propertyExpression,
			Func<DateTimePropertyConfiguration, DateTimePropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, DateTime>> propertyExpression,
			Func<DateTimePropertyConfiguration, DateTimePropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, decimal?>> propertyExpression,
			Func<DecimalPropertyConfiguration, DecimalPropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, decimal>> propertyExpression,
			Func<DecimalPropertyConfiguration, DecimalPropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
		public static EntityTypeConfiguration<TEntityType> Property<TEntityType>(
			this EntityTypeConfiguration<TEntityType> instance,
			Expression<Func<TEntityType, string>> propertyExpression,
			Func<StringPropertyConfiguration, StringPropertyConfiguration> propertyConfiguration)
			where TEntityType : class
		{
			propertyConfiguration(instance.Property(propertyExpression));
			return instance;
		}
	}
