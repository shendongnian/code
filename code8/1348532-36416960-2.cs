    public static void updateGold()
    {
        Debug.Log(Money.gold);
        golText.text = Money.gold.ToString();
    } 
    public static void updateDiamond()
    {       
        diaText.text = Money.diamond.ToString();
    }
    public void Awake()
    {
        golText = goldText.GetComponent<Text>();
        diaText = diamondText.GetComponent<Text>();
        updateGold();
        updateDiamond();
    }
