    public void Update()
     {
     float animationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
     // (I hope)
     // in some cases, animationTime = animationTime %1f;
     Debug.Log("animationTime is " + animationTime);
     slider.value = animationTime;
     }
