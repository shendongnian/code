    public int cardIndex;       // indicates what the card is
    public bool show;           // shows or hides card
    
    public Sprite[] cardFronts; // collection of cards' front sides
    public Sprite cardBack;     // backside of all cards
    
    GameObject largeSprite;     //the large sprite that we will be changing!
    
    void Start()
    {
        largeSprite = GameObject.Find("Name of the large sprite"); //find our large sprite!
    }
    
    
    // if card is turned up, show front of card, show back otherwise
    public void DisplaySprite()
    {
        if (show)
            gameObject.sprite = cardFronts[cardIndex]; //or it could be gameObject.renderer.sprite, I havent tested!
        else
            gameObject.sprite = cardBack;
    }
    
    void Awake()
    {
        DisplaySprite(); // show card's sprite
    }
    
    void OnMouseDown()
    {
        largeSprite.sprite = gameObject.sprite; //make the large one have the same as the small one!
    }
