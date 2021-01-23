    // in script for HP bar
    public Boolean TryDestroy()
    {
        if (shipHp <= 0)
        {
            Destroy (correspondingHpBar); 
            Destroy (gameObject); 
            return true;
        }
        return false;
    }
    // in another script
    private List<HPBar> _allHPBars;
    void Awake()
    {
        _allHPBars = new List<HPBar>(FindObjectsOfType(typeof(HPBar)));
    }
    
    void Update()
    {
        var destroyedHPBars = new List<HPBar>();
        foreach (var hpBar in _allHPBars)
        {
            if (hpBar.TryDestroy())
            {
                destroyedHPBars .Add(hpBar);
            }
        }
        foreach (var destroyedBar in destroyedHPBars)
        {
            _allHPBars.Remove(destroyedBar);
        }
    }
