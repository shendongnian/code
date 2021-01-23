    #region StaticVariables
    public static IUnityContainer unityContainer { get; set; }
    #endregion
    
    #region StaticMethod
    static void Main(string[] args)
    {
        var program = new Program();
        unityContainer = new UnityContainer().LoadConfiguration();
        foreach (var unityContainerRegistration in unityContainer.Registrations)
            Console.WriteLine($"{unityContainerRegistration.Name } | { unityContainerRegistration.RegisteredType} | { unityContainerRegistration.MappedToType} | { unityContainerRegistration.LifetimeManager.InUse }");
    }
    #endregion
