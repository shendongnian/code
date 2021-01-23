    int currentHeartsCount = 3;
    int maxHeartsCount = 3;
    List<Heart> hearts = new List<Heart>();
    public void TakeDamage(int damage) {
        ChangeHearts(-damage);
    } 
   
    public void GainLife(int life) {
        ChangeHearts(life);   
    }
    private void ChangeHearts(int amount) {
        currentHeartsCount += amount;
        if(currentHeartsCount> maxHeartsCount)
            currentHeartsCount = maxHeartsCount;
        if(currentHeartsCount<=0) {
            // call player dead code
        }
        int i = 1;
        foreach(Heart heart in hearts) {
            heart.SetHeartActive(i<=currentHeartsCount);
            i++;
        }
    }
