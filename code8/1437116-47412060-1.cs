    private static StandaloneInputModuleV2 currentInput;
    private StandaloneInputModuleV2 CurrentInput
    {
        get
        {
            if (currentInput == null)
            {
                currentInput = EventSystem.current.currentInputModule as StandaloneInputModuleV2;
                if (currentInput == null)
                {
                    Debug.LogError("Missing StandaloneInputModuleV2.");
                    // some error handling
                }
            }
    
            return currentInput;
        }
    }
...
    var currentGO = CurrentInput.GameObjectUnderPointer();
