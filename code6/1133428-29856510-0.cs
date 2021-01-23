    private Toggle toggle;
    public void Awake() {
       toggle = GetComponent<Toggle>();
    }
    public void SetBool(ref bool boolToSet) {
        if (toggle != null) {
            boolToSet = gameObject.GetComponent<Toggle>.isOn;
        }
    }
