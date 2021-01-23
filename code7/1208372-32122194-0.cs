    if (_wsHistory.id_terminal == 0)
     {
                Context.Response.Status = "404 Terminal table Not Found";
                //the next line is untested - thanks to strider for this line
                Context.Response.StatusCode = 404;
                //the next line can result in a ThreadAbortException
                //Context.Response.End(); 
                Context.ApplicationInstance.CompleteRequest();
                return null;
    }
