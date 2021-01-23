    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            StartCoroutine("DamageOverTimeCoroutine");
        }
        if (coll.gameObject.tag == "Ball")
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(Level);
        }
    }
    public IEnumerator DamageOverTimeCoroutine()
    {
        var dotHits = 0;
        while (dotHits < 4)
        {
            //Will remove 1/4 of Damage per tick
            GameObject.Find("Player").GetComponent<PlayerHealth>().PlayerHP -= Damage / 4;
            dotHits++;
            //Will return control over here
            yield return new WaitForSeconds(DamageInterval_DOT);
            //And then control is returned back here once 0.25s passes
        }
    }
