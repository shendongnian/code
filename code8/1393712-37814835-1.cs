    using UnityEngine;
    using System.Collections;
    
    public class SpriteAnimation
    {
        SpriteAnimator spriteAnimator;
        GameObject gameObj;
    
        public void setupSprites(string animationName, SpriteRenderer displaySprite, string animSprite1, string animSprite2)
        {
            gameObj = new GameObject(animationName);
            gameObj.AddComponent<SpriteAnimator>();
            spriteAnimator = gameObj.GetComponent<SpriteAnimator>();
            spriteAnimator.setupSprites(displaySprite, animSprite1, animSprite2);
        }
    
        public void startAnimation(float time = 0.5f)
        {
            spriteAnimator.startAnimation(time);
        }
    
        public void stopAnimation()
        {
            spriteAnimator.stopAnimation();
        }
    
        public void Destroy()
        {
            spriteAnimator.removeAnimation();
        }
    }
