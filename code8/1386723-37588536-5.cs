    void Start()
    {
        StartCoroutine(rotateObject(objectToRotate, new Vector3(0, 0, 90), 3f));
    }
    
    bool rotating = false;
    public GameObject objectToRotate;
    IEnumerator rotateObject(GameObject gameObjectToMove, Vector3 eulerAngles, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;
    
        Vector3 newRot = gameObjectToMove.transform.eulerAngles + eulerAngles;
    
        Vector3 currentRot = gameObjectToMove.transform.eulerAngles;
    
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.eulerAngles = Vector3.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
    }
