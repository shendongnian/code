    // Calls callback after final has been assigned
    IEnumerator WaitForFinal(System.Action callback) 
    {
        while(final == null)
            yield return null; // Wait for next frame
        callback();
    }
    
    // This whole method depends on final. 
    // This should be similar to your method set up if you have 
    // good coding standards (not very long methods, each method does only 1 thing)
    void MethodThatUsesFinal()
    {
        if (final == null)
        {
            // Waits till final is assigned and calls this method again
            StartCoroutine(WaitForFinal(MethodThatUsesFinal));
            return;
        }
    
        // use final
    }
