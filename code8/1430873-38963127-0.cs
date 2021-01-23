    public IEnumerator ReplaceCoroutine()
    {
        // check if the piece has an animation attached
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.Play(clearAnimation.name);
            yield return new WaitForSeconds(clearAnimation.length);
        }
    }
    
    IEnumerator playAll()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return pieces[i].StartCoroutine(ReplaceCoroutine());
        }
    }
