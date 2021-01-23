    void Start()
    {
        Quaternion rotation2 = Quaternion.Euler(new Vector3(0, 0, 90));
        StartCoroutine(RotateObject(objectToMove, rotation2, 3f));
    }
    
    bool rotating = false;
    public GameObject objectToMove;
    IEnumerator RotateObject(GameObject gameObjectToMove, Quaternion newRot, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;
    
        Quaternion currentRot = gameObjectToMove.transform.rotation;
        newRot = Quaternion.Euler(gameObjectToMove.transform.eulerAngles + newRot.eulerAngles);
    
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
    }
