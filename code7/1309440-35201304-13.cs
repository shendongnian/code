    private float rememberTheSpeedBecauseWeMightNeedIt;
    public void UserClickedPauseButton()
      {
      if ( animator.speed > 0f )
       {
       // we need to pause animator.speed
       rememberTheSpeedBecauseWeMightNeedIt = animator.speed;
       animator.speed = 0f;
       }
      else
       {
       // we need to "unpause"
       animator.speed = rememberTheSpeedBecauseWeMightNeedIt;
       }
      }
