    if (Constants.AllowedTyleTypes.Contains(currentTile.tyleType))
        {
            GameObject childSprite = currentTile.transform.FindChild("Sprite").gameObject;
            if (childSprite == null)
                throw new MissingComponentsForAnimationException(childSprite.Name, currentTile.Name);
    
            Animator spriteAnimator = childSprite.GetComponent<Animator>();
            spriteAnimator.SetBool("PassedBy", true); 
  
            if (spriteAnimator == null)
                throw new MissingComponentsForAnimationException(spriteAnimator .Name, currentTile.Name);
        }
