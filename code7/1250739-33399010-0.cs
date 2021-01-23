     public static class Extensions
        {
            public static TModel ObjectToModel<TSource, TModel>(this TSource source, string[] propsToExclude = null)
                where TModel : new()
            {
                var dest = new TModel();
    
                source.CopyPropertiesToObject(dest, propsToExclude);
    
                return dest;
            }
    
            public static bool CopyPropertiesToObject<T, TU>(this T source, TU dest, string[] propsToExclude = null)
            {
                try
                {
                    propsToExclude = propsToExclude ?? new string[0];
    
                    var sourceProps = typeof (T).GetProperties().Cast<PropertyInfo>().ToArray();
                    var destProps =
                        typeof (TU).GetProperties()
                            .Cast<PropertyInfo>()
                            .Where(
                                x =>
                                    x.CanWrite && sourceProps.Any(s => s.Name == x.Name) &&
                                    propsToExclude.All(e => e != x.Name)).ToArray();
    
                    foreach (var property in destProps)
                    {
                        var sourceProperty = sourceProps.FirstOrDefault(c => c.Name == property.Name);
                        if (source != null)
                        {
                            var value = sourceProperty.GetValue(source);
                            property.SetValue(dest, value);
                        }
                    }
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
    
        [TestClass]
        public class Scratch
        {
            [TestMethod]
            public void PropertiesMapAsExpected()
            {
                var model = new Model {Id = 2, Name = "foo"};
                var viewModel = model.ObjectToModel<Model, ViewModel>();
                Assert.AreEqual(model.Id, viewModel.Id);
                Assert.AreEqual(model.Name, viewModel.Name);
            }
    
            public class Model
            {
                public int Id { get; set; }
                public string Name { get; set; }
    
                public int NotMapped { get; set; }
            }
    
            public class ViewModel
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
        }
