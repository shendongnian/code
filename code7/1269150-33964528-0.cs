    public static E JobFromJson <E, I, T, K>(String json, TaskType task) where E : Job<I, T, K>
    {
        var method= typeof(JsonConvert).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m=>m.Name == "DeserializeObject" && m.GetGenericArguments().Length==1 && m.GetParameters().Length==1).Single();
        var concreteMethod = method.MakeGenericMethod(Task.GetJob<I, T, K>(task));
        return (E)concreteMethod.Invoke(null, new object[]{json});
    }
