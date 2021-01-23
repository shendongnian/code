    [TestClass]
    public class EFMappingTest {
        [TestMethod]
        public void MappperTest() {
            EntityFactory.Map<UsersBo, Users>();
            EntityFactory.Map<RolesBo, Roles>();
            EntityFactory.Map<AppObjectsBo, AppObjects>();
            var factory = new EntityFactory();
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
        public class EntityFactory {
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
            public TEntity CreateEntity<TEntity>(object businessObject) where TEntity : class {
                if (businessObject == null) throw new ArgumentNullException("businessObject");
                Type businessObjectType = businessObject.GetType();
                Type entityType = null;
                return mappings.TryGetValue(businessObjectType, out entityType)
                    ? (TEntity)Activator.CreateInstance(entityType)
                    : null;
            }
        }
    }
