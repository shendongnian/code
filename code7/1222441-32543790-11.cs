    OurFramework framework = new OutFramework();
    //some inicialization
    //the user should call here: framework.SetRules("rule");
    bool isValid = false;
    try
    {
        isValid = framework.Validate(input);
    }
    catch(OurFrameworkInvalidOperationException)
    {
        //tell the user that the rules are not filled in in the GUI somewhere.
    }
    catch(OurFrameworkOtherException)
    {
        //give the user a similar warning as previously about something else.
    }
    catch(OurFrameworkException)
    {
        //a general unspecified framework error occurred in the framework.
    }
    catch(Exception) //everything else
    {
        //something unrelated to the framework or unhandled in the framework occurred.
    }
    if (isValid)
    {
        //do stuff.
    }
