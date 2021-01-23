        // Update is called once per frame
    void Update () 
    {
        while(isAttacking == true)
        {
            if(Health <= 0)
            {
                isAttacking = false;
                Debug.Log ("Is attacking: " + isAttacking);
                Destroy(this.gameObject);
                Debug.Log ("Enemy Destroyed!");
            }
    
            //Constantly move the enemy towards the centre of the gamespace (where the base is)
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
