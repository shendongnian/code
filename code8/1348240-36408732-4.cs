    void Start()
      {
      Debug.Log("Audio begins now.....");
      Invoke("TwoMinutesHasPassed", 120f);
      }
     
    void TwoMinutesHasPassed()
      {
      Debug.Log("two minutes has passed");
      Debug.Log("now i will fade the background");
      StartCoroutine("FadeNow");
      }
    private IEnumerator FadeNow()
      {
      tParam = 0f;
      while (tParam < 1)
        {
        tParam += Time.deltaTime * speed;  
        valToBeLerped = Mathf.Lerp(0, 1, tParam);
        Debug.Log("valToBeLerped is " + valToBeLerped.ToString("f4"));
        yield return null;
        }
      skyboxmaterial.SetFloat("_Blend", valToBeLerped);
      Debug.Log("fade is done.");
      }
