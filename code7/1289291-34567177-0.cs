    public IEnumerator DamageOverTimeCoroutine()
    {
        var dotHits = 0;
        var playerHP = GameObject.Find("Player").GetComponent<PlayerHealth>().PlayerHP;
        while (dotHits < 4)
        {
            //Will remove 1/4 of Damage per tick
            playerHP -= Damage / 4;
            //Will return control over here
            yield return new WaitForSeconds(DamageInterval_DOT);
            //And then control is returned back here once 0.25s passes
        }
    }
