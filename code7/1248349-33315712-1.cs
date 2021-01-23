    void Start()
    {
        StartCoroutine(F());
    }
    IEnumerator F()
    {
        // by yielding the Coroutine, it will block the execution of
        // this coroutine (F) until MyCoroutine finishes
        yield return StartCoroutine(MyCoroutine(1.52f));
        // This is no longer doing much, really.
        yield return StartCoroutine(Killer(2f));
        print("done");
    }
