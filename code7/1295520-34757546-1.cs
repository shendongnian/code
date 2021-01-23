    void OnCollisionEnter(Collision collision){
        ...
        // Cancel the invoke to 'reset' it
        CancelInvoke("VoicePrompt");
        // And start it again
        InvokeRepeating("VoicePrompt", 0f, 20f);
        ...
    }
