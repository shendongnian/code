    public static IEnumerable<String> ColorsWithoutTransparent
    {
        get
        {
            var colors = typeof (Colors);
            return colors.GetProperties().Select(x => x.Name).Where(x => !x.Equals("Transparent"));
        }
    }
