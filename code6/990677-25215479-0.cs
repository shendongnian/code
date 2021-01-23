    class A
    {
        public int B()
        {
            return 1;
        }
    }
    
    class B : DynamicObject
    {
        private readonly A m = new A();
    
        private static readonly Lazy<IEnumerable<MethodInfo>> AMethods =
            new Lazy<IEnumerable<MethodInfo>>(() =>
                                              {
                                                  var type = typeof (A);
                                                  return type.GetMethods(
                                                      BindingFlags.Instance | 
                                                      BindingFlags.Public);
                                              });
    
        public override bool TryInvokeMember(
                               InvokeMemberBinder binder, 
                               object[] args, 
                               out object result)
        {
            if (base.TryInvokeMember(binder, args, out result))
            {
                return true;
            }
            
            var methods = AMethods.Value;
    
            var method = methods.FirstOrDefault(mth => mth.Name == binder.Name); 
                // TODO: additional match (arguments type to handle overloads)
            if (method == null)
            {
                result = null;
                return false;
            }
    
            result = method.Invoke(this.m, args);
    
            return true;
        }
        
        public int OtherBMethods()
        {
            return 2;
        }
    }
