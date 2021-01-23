    public static UnityDependencyResolver RegisterComponents()
    {....
        var container = new UnityContainer();
        ///here all my registertypes
        return new UnityDependencyResolver(container);
    }
