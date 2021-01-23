    [EDIT TO CLASS]
    public abstract class AnimalAgressive<TEnemy> : AnimalAggresiveBase where TEnemy : class, new(){
    [EDIT TO METHOD]
    public string Bark<TAnimal>(TAnimal animal){
                var typeAnimal = typeof(TAnimal);
                var typeEnemy = typeof(TEnemy);
    
                var propsAnimal = typeData.GetProperties();
                var propsEnemy = typeGener.GetProperties();
    
                var obj = new T();
    
                foreach (var propertyInfo in propsAnimal)
                {
                    var value = propertyInfo.GetValue(dataObject);
                    try
                    {
                        var propEnemy  = propsEnemy.FirstOrDefault(x => x.Name.Equals(propertyInfo.Name, StringComparison.CurrentCulture));
                        propGener?.SetValue(obj, value, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
    
                return Bark(obj.Name);
