    StartCoroutine(firstParsing((value)=>{main = value;
         final= main.Copy();
         Debug.Log(main);
         OnFinalAssigned(final);
    }));
    Debug.Log(final);
    } // End Start()
    void OnFinalAssigned(JSONObject final)
    {
        // Do whatever you want with final here
        // use it, parse it, delete it, raise another event (call another function)
    }
