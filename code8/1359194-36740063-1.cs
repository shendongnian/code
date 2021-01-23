    private readonly UserGroupRepository _GroupRepository;
    
    public IEnumerable<UserGroupModel> GetListedGroups()
    {
        var list = this._GroupRepository.GetAll();
        var userCount = this._GroupRepository.GetUserCountInGroup();
        // Do something here.
    }
