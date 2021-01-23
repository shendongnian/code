    public void update()
     {
     float animationTime = animator["Take 001"].normalizedTime;
     // (I think)
     Debug.Log("animationTime is " + animationTime);
     slider.value = animationTime;
     }
