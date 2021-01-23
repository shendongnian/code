    static int _geneLength = 36;
    public int geneLength { get; private set; }
    
    public Creature() { this.geneLength = _geneLength; }
    public Creature(int geneLength) { this.geneLength = geneLength; }
