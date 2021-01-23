    void Start()
     {
     ShowMiniPuzzleOnScreen();
     Invoke("TimeIsUpForUser", 60f);
     } 
    
    private void UserHasPlacedFinalPieceOfPuzzle()
     {
     MessageScreen("Congratulations! You get 100 coins!");
     balance += 100;
     CancelInvoke("TimeIsUpForUser");
     }
    
    private void TimeIsUpForUser()
     {
     HideMiniPuzzle();
     PlaySadMusic();
     MessageScreen("You suck! You are too slow. You lose 50 points.");
     balance -= 50;
     }
