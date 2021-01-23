    public GameObject objectectA;
    public GameObject objectectB;
    
    void Start()
    {
        StartCoroutine(moveToPos(objectectA.transform, objectectB.transform.position, 1.0f));
    }
    
    
    bool isMoving = false;
    IEnumerator moveToPos(Transform fromPosition, Vector3 toPosition, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;
    
        float counter = 0;
    
        //Get the current position of the object to be moved
        Vector3 startPos = fromPosition.position;
    
        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector3.Lerp(startPos, toPosition, counter / duration);
            yield return null;
        }
    
        isMoving = false;
    }
 
