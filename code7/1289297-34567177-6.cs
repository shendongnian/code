    public IEnumerator DamageOverTimeCoroutine()
    {
        var dotHits = 0;
        var player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        while (true)
        {
            //Stop removing damage, player is dead already
            if (player.PlayerHP <= 0)
                yield break;
            //Will remove 5 Damage per tick
            player.PlayerHP -= 5;
            dotHits++;
            //Will return control over here
            yield return new WaitForSeconds(DamageInterval_DOT);
            //And then control is returned back here once 0.25s passes
        }
    }
