    public void OnTriggerStay2D(Collider2D other)
    {
            if (Enemy.Found != true) {
                if (other.tag == "Player") {
                    Enemy.Shield = true;
                    IEnemy.dle = false;
                } 
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Enemy.Exit2DTrigger();
        } 
    }
