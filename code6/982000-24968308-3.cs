    kernel.Bind<IWheel>().To<Wheel2>()
          .WhenIsDescendantOf(typeof(Mechanism1));
    public static class NinjectWhenExtensions
    {
        public static IBindingInNamedWithOrOnSyntax<T> WhenIsDescendantOf<T>(this IBindingWhenSyntax<T> syntax, Type ancestor)
        {
            return syntax.When(request => request.ActiveBindings.Any(p => p.Service.Name == ancestor.Name));
        }
    }
