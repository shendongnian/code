    private float GetApproximatedTime(float u)
    {
    int resolution = 25 * SelectedSpline.CurveCount; // Factor in additional curves.
    float ratio = 1.0f / resolution;
    float arcLength = 0.0f;
    Vector3 p0 = SelectedSpline.Evaluate(0.0f);
    List<MultiCurveUtility.ArcTimeLength> arcTimeLengthMap = new List<MultiCurveUtility.ArcTimeLength>();
    arcTimeLengthMap.Add(new MultiCurveUtility.ArcTimeLength(0.0f, 0.0f));
    for (int i = 1; i <= resolution; i++)
    {
        float t = ((float)i) * ratio;
        Vector3 p1 = SelectedSpline.Evaluate(t);
        arcLength += Mathf.Abs(p1.x - p0.x); // Only use the x-axis delta.
        arcTimeLengthMap.Add(new MultiCurveUtility.ArcTimeLength(t, arcLength));
        p0 = p1;
    }
    float target = u * arcLength;
    int low = 0;
    int high = 1;
    float min = 0.0f;
    float max = 0.0f;
    for (int i = 1; i < arcTimeLengthMap.Count; i++)
    {
        max = arcTimeLengthMap[i].ArcLength;
        if (target > min && target < max) 
        {
            high = i;
            low = i - 1;
            break; 
        }
        min = max;
    }
    float p = (target - min) / (max - min);
    float lowTime = arcTimeLengthMap[low].ArcTime;
    float highTime = arcTimeLengthMap[high].ArcTime;
    float lowHighDelta = highTime - lowTime;
    return arcTimeLengthMap[low].ArcTime + (lowHighDelta * p);
    }
