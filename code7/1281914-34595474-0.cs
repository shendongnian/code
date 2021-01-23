    void Awake()
         {
             syncPos = GetComponent<Player_SyncPosition>();
         }
     
    void Update()
     {
      if ((input.x > 0 && !facingRight) || (input.x < 0 && facingRight))
             {
                 facingRight = !facingRight;
                 syncPos.CmdFlipSprite(facingRight);
             }
     }
