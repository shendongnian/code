    StartCoroutine(firstParsing((value)=>{main = value;
        final= main.Copy();
        Debug.Log(main);
        isFinalAssigned = true;
    }));
    // In another method
    if(isFinalAssigned)
    {
        // Access final
    }
