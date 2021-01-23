    // POST api/mycontrollername
    public HttpResponseMessage Post(FormDataCollection fdc)
    {
        try
        {
            if (fdc != null)
            {
                MyClass myInstance = new MyClass();
                IEnumerator<KeyValuePair<string, string>> pairs = fdc.GetEnumerator();
                while (pairs.MoveNext())
                {
                    switch (pairs.Current.Key)
                    {
                        case "PhoneNumber":
                            myInstance.PhoneNumber = pairs.Current.Value;
                            break;
                        ...
                        default:
                            // handle any additional columns
                            break;
                    }
                }
                // do stuff with myInstance
                // respond with OK notification
            }
            else
            {
                // respond with bad request notification
            }
        }
        catch (Exception ex)
        {
            // respond with internal server error notification
        }
    }
