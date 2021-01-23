    IEnumerator GetAverageMovement(Action<Vector3> result)
    {
        int frames = 0; 
        List<Vector3>list = new List<Vector3>();
        while(frames < 30f) // half a second appr
        {
            list.Add(GetDirection());
            frames++;
            yield return null;
        }
        result(AverageAllValues()); 
    }
