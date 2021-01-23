    foreach( ActivitySteps del in this.activitySteps.GetInvocationList() )
    {
        try
        {
            del.Invoke( inputFolder, outputFolder );
        }
        catch( Exception ex )
        {
            Console.WriteLine( "{0} threw {1}", del.Method.Name, ex );
        }
    }
