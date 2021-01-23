    var actS = aActionCur._EnmGetValues().GetAsActionList();
    actS.ForEach(act => Console.WriteLine("action [{0}] {1}", actS.CurId, act));
    //which is using....v
    public static ListWithCounter<Enum> _EnmGetValues(this Enum Self)
    {
        ListWithCounter<Enum> enumerations = new ListWithCounter<Enum>();
        foreach (FieldInfo fieldInfo in Self.GetType().GetFields(
                  BindingFlags.Static | BindingFlags.Public))
        {
                enumerations.Add((Enum)fieldInfo.GetValue(Self));
        }
            return enumerations;
    }
    //which is using....v
    public static ListWithCounter<T> ForEach<T>(this  ListWithCounter<T> Self, Action<T> itm)
    {
            for (int i = 0; i < Self.Count; i++)
            {
                itm(Self[i]); Self.CurId++;
            }
            return Self;
    }
