    // INSIDE CONTROLS COMPONENT
    private void OnTriggerEnter(Collider c)
    {
        if(c.tag == "SpeedBoostPowerUp")
        {
            if (!flag)
            {
                StartCorouting(BoostSpeed);
            }
        }
    }
    public void MultiplySpeed()
    {
        this.speed = this.speed * this.multiplier;
    }
    
    public void BackToNormal()
    {
        this.speed = this.speed / this.multiplier;
    }
    
    private IEnumerator BoostSpeed()
    {
        flag = true;
        MultiplySpeed();
        yield return new WaitForSeconds(5);
        BackToNormal();
        flag = false;
    }
    
