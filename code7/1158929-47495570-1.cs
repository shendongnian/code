    private void Please(string Action, object Obj)
    {
        MethodInfo method = Obj.GetType().GetMethod(Action, Type.EmptyTypes, null);
        if (method != null)
        {
            method.Invoke(Obj, new object[] { });
        }
        else
        {
            Console.WriteLine(string.Format("I can not {0} because {1}", Action, WhoAreYou(Obj)));
        }
    }
    private string WhoAreYou(object unknown)
    {
        string question = "WhoAreYou";
        MethodInfo whoAreYou = unknown.GetType().GetMethod(question, Type.EmptyTypes, null);
        return whoAreYou.Invoke(unknown, new object[] { }).ToString();
    }
