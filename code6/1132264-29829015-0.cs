    private string equ;
    [ForeignKey("Equipo")]
    public string EQU
    {
        get { return equ.Capitalize(); }
        set { equ = value; }
    }
    private Equipo equipo;
    public virtual Equipo Equipo
    {
        get { return equipo; }
        set { equipo = value; }
    }
    public static string Capitalize(this string str)
    {
        if (str != null || str == "")
        {
            str = str.ToLower();
            str = Regex.Replace(str, @"\b[a-z]", delegate(Match m)
            {
                return m.Value.ToUpper();
            });
        }
        return str;
    }
