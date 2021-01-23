    private Boolean _Active;
    public String Active
    {
        get
        {
            return (_Active == true ? "Aktiv" : "Inaktiv");
        }
        set
        {
            _Active = Convert.ToBoolean(value);
        }
    }
