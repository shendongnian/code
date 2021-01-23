        public static Type[] GetBindings(this IKernel kernel)
        {
            return ((Multimap<Type, IBinding>)typeof(KernelBase)
                .GetField("bindings", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(kernel)).Select(x => x.Key).ToArray();
        }
