    using UnityEngine;
    using System.Collections;
    
    using UnityEngine;
    using System.Collections;
    
    public class MultiplySpeed : MonoBehaviour
    {
        public int multiplier = 2;
        public Controls player;
        bool flag = false;
        float timer = 5.0f;
        bool countDown = false;
    
        void update()
        {
            if (countDown)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    backToNormal();
                    countDown = false;
                }
            }
    
        }
        void OnTriggerExit(Collider c)
        {
            if (c.tag == "Player")
            {
                player = c.gameObject.GetComponent<Controls>();
                if (!flag)
                {
                    countDown = true;
                    timer = 5.0f;
                    flag = true;
                    multiplySpeed();
                }
            }
        }
        public void multiplySpeed()
        {
            player.speed = player.speed * multiplier;
        }
        public void backToNormal()
        {
            player.speed = player.speed / multiplier;
        }
    }
