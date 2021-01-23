    void Update () {
        
        if (!animation.IsPlaying("yourWaterAnimationName"))
        {
            if (Input.GetButtonDown("Fire3"))
            {
                if (fireCount < waterBucketAmnt)
                {
                    fireCount++;
                }
            }
        }
        for (int i = 0; i < fireCount; i++)
        {
            animation.PlayQueued("yourWaterAnimationName");
            waterBucketAmnt--;
            fireCount--;
        }
        
    }
