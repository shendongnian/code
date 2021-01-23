    ISkill _Idefaultattack;
    public GameObject _defaultattack;
    void Start() {
        if (NetworkServer.active)
            Debug.Log("Actived");
        else
            Debug.Log("DeActived");
        if (isLocalPlayer) {
            _Idefaultattack = _defaultattack.GetComponent<SphereSkillDefault>();
            _Idefaultattack.initiate(this);
        }
    }
    void Update() {
        if (!isLocalPlayer) {
            return;
        }
        //_Idefaultattack.CmdAttack();
        CmdAck();
    }
    [Command]
    void CmdAck(){
        _Idefaultattack.CmdAttack();
    }
