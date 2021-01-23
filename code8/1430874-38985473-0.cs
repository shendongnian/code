    public IEnumerator ReplaceCoroutine()
    {
         for(int i=0; i<pieces.Length; i++)
         {
             // check if the piece has an animation attached
             Animator animator = pieces[i].GetComponent<Animator>();
             if (animator!=null)
             {
                animator.Play(pieces[i].clearAnimation.name);
                yield return new WaitForSeconds(pieces[i].clearAnimation.length/2.0f);
             }
        }
    }
    
    void startAnimationSequence
    {
        StartCoroutine(ReplaceCoroutine());
    }
