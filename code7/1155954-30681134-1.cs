    private Dictionary<Type,MethodInfo> cache = 
       new Dictionary<Type,MethodInfo>();
           
    public static void Initialize(Control control, 
         DocumentContainer container, ErrorProvider provider)
    {
        if (control == null) return;
        MethodInfo initializer = null;
        Type controlType = control.GetType();
        if(!cache.TryGetValue(controlType, out initializer)){
            initializer = typeof(ClassInitialor).GetMethod("InitializeControl",
                new Type[] {
                    controlType,
                    typeof(DocumentContainer),
                    typeof(ErrorProvider),
                });
            cache[controlType] = initializer;
        }
        initializer.Invoke(null,
            new object[] {
                 control,
                 container,
                 provider
            });
        
        foreach (Control subControl in control.Controls)
            Initialize(subControl, container, provider);
    }
