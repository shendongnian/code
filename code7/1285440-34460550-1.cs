    void Update ()
    {
        string scoreText = score.ToString ();
        for (int i = 0; i < scoreText.Length; i++)
        {
            var go = (GameObject)Instantiate(Resources.Load(scoreText[i].ToString());
            go.layer = 8;
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
        }
    }
