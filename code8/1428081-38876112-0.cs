    [TestClass]
    public class EFMappingTest {
        [TestMethod]
        public void MappperTest() {
            EntityMapper.Map<UsersBo, Users>();
            EntityMapper.Map<RolesBo, Roles>();
            EntityMapper.Map<AppObjectsBo, AppObjects>();
            var factory = new EntityMapper();
            var entity = factory.CreateEntity<UsersBo>();
            Assert.IsNotNull(entity);
            Assert.IsInstanceOfType(entity, typeof(Users));
        }
        class Users { }
        class UsersBo { }
        class Roles { }
        class RolesBo { }
        class AppObjects { }
        class AppObjectsBo { }
        public class EntityMapper {
            static IDictionary<Type, Type> mappings = new Dictionary<Type, Type>();
            public static void Map<TBusinessObject, TEntity>() where TEntity : class, new() {
                Map(typeof(TBusinessObject), typeof(TEntity));
            }
            public static void Map(Type sourceType, Type targetType) {
                mappings[sourceType] = targetType;
            }
            public object CreateEntity<T>() {
                Type entityType = null;
                return mappings.TryGetValue(typeof(T), out entityType)
                    ? Activator.CreateInstance(entityType)
                    : null;
            }
        }
    }
