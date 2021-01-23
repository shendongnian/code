    public static AbstractPlateforme GetPlateforme(Type type)
    {
        return (AbstractPlateforme)ListePlateforme.Find(x => x.GetType() == type);
    }
    public static T GetPlateforme<T>() where T : AbstractPlateforme
    {
        return (T)GetPlateforme(typeof(T));
    }
