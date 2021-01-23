    public class Foo_test : EntityContextIntegrationSpec
            {
    
                private static string _foo = null;
    
                private static DataConnection _result;
    
                private Because _of = () => _result = EntityContext.Set<E>().Where(StringMatch<E>(x => x.StringField));
    
                private static Expression<Func<TSource, bool>> StringMatch<TSource>(Expression<Func<TSource, string>> prop)
                {
                    var body = Expression.Equal(prop.Body, Expression.Constant(_foo));
                    return Expression.Lambda<Func<TSource,bool>>(body, prop.Parameters[0]);                
                }
    
                [Test] public void Test() => _result.ShouldNotBeNull();
            }
