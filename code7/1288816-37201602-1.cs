    bool animationClipPlaying = false;
    void Update()
    {
         if (GetComponent<Animation>().IsPlaying(clipNameCompare))
         {
             //as animation start to play true the bool
             animationClipPlaying = true; //true this for comparsion
         }
         //if animation is not playing and the bool is true then, animation finished
         else if (!GetComponent<Animation>().IsPlaying(clipNameCompare) && animationClipPlaying)
         {
             Debug.Log(clipNameCompare : " has finished");
             //False so that this condition run only once
             aanimationClipPlaying = false; 
         }
    }
