    public interface ITransformedBiscuit {}
    
    public class DigestiveBiscuit : ITransformedBiscuit {}
    
    public class ChocolateBiscuit : ITransformedBiscuit {}
    public class BiscuitTransformManager 
    {
        IBiscuit Transform(ITransformedBiscuit biscuit)
        {
            // Use a reflection in here 
            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                where typeof(ITransformedBiscuit).IsAssignableFrom(t)
                         && t.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(t) as ITransformedBiscuit;
            foreach (var instance in instances)
            {
                instance.Transform(biscuit)
            }
        }
    }
