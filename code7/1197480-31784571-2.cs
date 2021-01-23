    try
    {
        //exception-prone code block here
    }
    catch(KnowException1 ex)
    {
       Logger.Log(ex); //logging may be optional as its a known handled situation
       //perform predefined action
    }
    catch(KnowException2 ex)
    {
       Logger.Log(ex); //logging may be optional as its a known handled situation
       // fire message box asking users how to proceed
       //perform selected predefined action
    }
    catch(UnknowException ex)
    {
       Logger.Log(ex); //logging is vital
       // fire message box something unexpected happened
       //cancel action and return to normal operations
    }
