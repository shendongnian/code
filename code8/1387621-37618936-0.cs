    IEnumerator MouseMovement()
    {
        while(true)
        {
            if(MouseMoved)
            {
               //Do stuff
            }
            yield return new WaitForSeconds(1f);
        }
    }
