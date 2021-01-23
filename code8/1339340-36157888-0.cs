    private float maxThrotle;
    public float MaxThrotle {
        set { maxThrotle = value < 0 ? -value : value;    //this line causes problem
        }
        get { return maxThrotle; }
    }
