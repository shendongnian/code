    private List<string> _givenPermission;
    public List<string>  GivenPermission
    {
        get { return _givenPermission; }
        set { _givenPermission = value; lstGivenPermissions.DataSource = value; }
    }
