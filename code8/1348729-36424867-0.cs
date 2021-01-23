    internal class PersonBindingGenerator : IBindingGenerator
    {
        private static readonly MethodInfo PopulateOpenGenericMethodInfo =
            typeof(IProfileService).GetMethod("PopulateProfile");
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(
            Type type,
            IBindingRoot bindingRoot)
        {
            yield return bindingRoot
                .Bind(type)
                .ToMethod(x => CreatePerson(x.Kernel.Get<IProfileService>(), type));
        }
        private static object CreatePerson(
            IProfileService profileService,
            Type type)
        {
            var closedGeneric = PopulateOpenGenericMethodInfo.MakeGenericMethod(type);
            return closedGeneric.Invoke(profileService, new object[0]);
        }
    }
