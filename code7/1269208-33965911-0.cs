    whatever.GetType().GetFields ....
----
    public static string ShowFields(object whatever)
    {
        string S = "";
        foreach(var field in whatever.GetType().GetFields(
            BindingFlags.Instance |
            BindingFlags.NonPublic |
            BindingFlags.Public))
        {
            S = S + field.Name + ": " + field.GetValue(whatever).ToString() + "\n";
        }
        return S;
    }
