    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class Hearts : MonoBehaviour
    {
    
        public Image[] initialHeart;
        private int hearts;
        private int currentHearts;
        // Use this for initialization
    
        //Used for chaching Image so that you won't be doing GetComponent<Image>(); each time
        Image heartImage;
    
        void Start()
        {
            //Cache the Image once so that you won't be doing GetComponent<Image>(); each time
            heartImage = GetComponent<Image>();
            heartImage.sprite = initialHeart[0].sprite;
            hearts = initialHeart.Length;
    
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    
        public bool TakeHeart()
        {
            if (hearts < 0)
            {
                return false;
            }
    
            if (currentHearts < (hearts - 1))
            {
    
                currentHearts += 1;
                heartImage.sprite = initialHeart[currentHearts].sprite;
                return true;
    
    
            }
            else
            {
    
                return false;
    
            }
        }
    
    
    
        public bool AddHeart()
        {
    
            if (currentHearts > 0)
            {
                currentHearts -= 1;
                heartImage.sprite = initialHeart[currentHearts].sprite;
                return true;
            }
            else
            {
                return false;
    
            }
        }
    }
