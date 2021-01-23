    using UnityEngine;
    using System.Collections;
    
    public class SpriteAnimator : MonoBehaviour
    {
        bool continueAnimation = false;
    
        SpriteRenderer displaySprite;
        Sprite sprite1;
        Sprite sprite2;
    
        public void setupSprites(SpriteRenderer displaySprite, string animSprite1, string animSprite2)
        {
            //Set where the animated sprite will be updated
            this.displaySprite = displaySprite;
    
            //Load Sprite 1
            Texture2D tex = Resources.Load<Texture2D>(animSprite1) as Texture2D;
            sprite1 = Sprite.Create(tex, new Rect(0, 0, 250, 150), new Vector2(0.5f, 0.5f), 40);
    
            //Load Sprite 2
            Texture2D tex2 = Resources.Load<Texture2D>(animSprite2) as Texture2D;
            sprite2 = Sprite.Create(tex2, new Rect(0, 0, 250, 150), new Vector2(0.5f, 0.5f), 40);
        }
    
        private IEnumerator startAnimationCRT(float time)
        {
            if (continueAnimation)
            {
                yield break;
            }
            continueAnimation = true;
    
            WaitForSeconds waitTime = new WaitForSeconds(time);
            while (continueAnimation)
            {
                //Change to Sprite1
                displaySprite.sprite = sprite1;
    
                //Wait for `time` amount
                yield return waitTime;
    
                //Change Sprite
                displaySprite.sprite = sprite2;
    
                //Wait for `time` amount
                yield return waitTime;
            }
    
            continueAnimation = false;
        }
    
        public void startAnimation(float time)
        {
            StartCoroutine(startAnimationCRT(time));
        }
    
        public void stopAnimation()
        {
            continueAnimation = false;
        }
    
        public void removeAnimation()
        {
            Destroy(this.gameObject);
        }
    }
