        public GameObject panel;
        public bool hasShield = false; /* no shield in the beginning */    
        void OnCollisionEnter(Collision col)
        {
            if(col.gameObject.tag == "Shield") 
            {
                 hasShield = true; //We are safe now.
                 /* TODO: StartCoroutine() or Invoke() to reset the variable and the graphic effect after some amount of time. */
            }
            else if (col.gameObject.tag == "Monster") 
            { 
                if(!hasShield)
                    panel.SetActive (true);  //We hit a monster and had no shield. Display gameover.
                else
                    hasShield = false; //loose the shield
            }
            //I assume the panel is inactive by default so no need to call SetActive(false) on it.
        } 
