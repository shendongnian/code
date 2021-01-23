    public class FooValidator : AbstractValidator<Foo>
    {
        public FooValidator()
        {
            Custom(foo =>
            {
                var repo = new Repository<Foo>();
                var otherFooFromDB = repo.GetByName(foo.Name);
    
                if (!otherFooFromDB.Equals(foo))
                {
                    return new ValidationFailure("Id", "The foo with ID'" + otherFooFromDB.Id + "' has the same name of this new item '" + foo.Id + " - " + foo.Name + "'.!");
                }
                else
                {
                    return null;
                }
            });
        }
    }
