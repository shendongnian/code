    public class CustomResolver : ValueResolver<SuperModel, Entity2>
    {
        protected override Entity2 ResolveCore(SuperModel source)
        {
            return new Entity2
            {
                Children = source.Model2.Children,
                HasPet = source.Model2.HasPet,
                Married = source.Model2.Married,
                NickName = source.Model1.NickName
            };
        }
    }
