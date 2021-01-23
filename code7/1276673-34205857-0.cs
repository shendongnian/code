    public static object GetPlateforme(Type type)
    {
        return ListePlateforme.Find(x => x.GetType() == type);
    }
    public static T GetPlateforme<T>() where T : AbstractPlateforme
    {
        return (T)GetPlateforme(typeof(T));
    }
