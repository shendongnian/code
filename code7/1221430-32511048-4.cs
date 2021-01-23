    public GameObject grenadeObject;
    void Update() {
       if (Input.GetKeyDown(KeyCode.I)) {
                        
           animator.SetBool("Grenade", true);
           GrenadeThrow();
        }
    }
    void GrenadeThrow() {
        StartCoroutine(COPlayOneShot("Grenade")); // unknown function
        Grenade grenade = Instantiate(grenadeObject, new Vector3(10 * 2.0F, 0, 0), Quaternion.identity).GetComponent<Grenade> ();
        grenade.direction = Vector3.one; // change this to the appropriate direction
        grenade.speed = 10f; // change this to the appropriate speed
    }
    IEnumerator GrenadeCooldown() {
        canFire = false;
        yield return new WaitForSeconds(0.01f);
        //rifleMuzzle.GetComponent<ParticleSystem>().top();
        canFire = true;
        animator.SetBool("Grenade",false);
    }
