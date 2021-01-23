    float[] testNums = { 2f, 3.4f, 7.59f, 22f, 37.3f, 104f, 351.7f };
    string[] output = new string[testNums.Length];
    string lowValueFormat = "0.#";
    for (int i = 0; i < testNums.Length; i++)
    {
        string strNum;
        if (testNums[i] < 10)
        {
            strNum = testNums[i].ToString(lowValueFormat);
        }
        else
        {
            strNum = Math.Floor(testNums[i]).ToString();
        }
        output[i] = strNum;
    }
    Debug.Log(string.Join(", ", output));
