    internal class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("Users");
            HasKey(u => u.Id);
            Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("UserID");
            var userType = typeof (User);
            var propertyInfo = userType.GetProperty("UserRoles", BindingFlags.NonPublic | BindingFlags.Instance);
            var parameter = Expression.Parameter(typeof (User), "u");
            var property = Expression.Property(parameter, propertyInfo);
            var funcType = typeof (Func<,>).MakeGenericType(userType, typeof (ICollection<Role>));// propertyInfo.PropertyType);
            var lambda = Expression.Lambda(funcType, property, parameter);
            ((ManyNavigationPropertyConfiguration<User, Role>)GetType().GetMethod("HasMany")
                .MakeGenericMethod(typeof(Role))
                .Invoke(this, new object[] { lambda }))
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                    m.ToTable("UserRoles");
                });
            }
        }
    }
