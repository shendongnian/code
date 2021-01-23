        // Update is called once per frame
    void Update () 
    {
        while(isAttacking == true)
        {
            if(Health <= 0)
            {
                Debug.Log ("Is attacking: " + isAttacking);
                Destroy(this.gameObject);
                Debug.Log ("Enemy Destroyed!");
                isAttacking = false;
            }
    
            //Constantly move the enemy towards the centre of the gamespace (where the base is)
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
