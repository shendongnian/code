    public class NancyContextWrapperRegistrations : IRegistrations
    {
        public IEnumerable<TypeRegistrations> TypeRegistrations 
        {
            get 
            { return new[]
                   {
                       new TypeRegistration(typeof(INancyContextWrapper), typeof(NancyContextWrapper), Lifetime.PerRequest),
                       new TypeRegistration(typeof(IUrlString .... per request
                   }
                   // or you can use AssemblyTypeScanner, etc here to find
            }    
    
            //make the other 2 interface properties to return null
        }
    }
