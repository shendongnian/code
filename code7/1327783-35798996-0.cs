    public static void SlowCalculation(params, System.Security.Principal.GenericPrincipal principal)
    {
        _calculationIsRunning = true;
        if (principal?.IsInRole("MySecurityGroup") ?? false)
        {
            // lots of long calculations
            _resutsAreReady = true;
            _calculationIsRunning = true;
        }
    }
    //
    // POST: /Get/
    public ActionResult GetResults(params)
    {
        if (_calculationIsRunning)
            return View("InProgress");
        else if (_resutsAreReady)
            return View("Results", results);
        else            
        {
            // start the calcualtion on a new thread to avoiding having very long running connection that azure will close
                    var principal = System.Security.Principal.GenericPrincipal.Current;
            System.Threading.Tasks.Task.Run(() => SlowCalculation(params, principal ));
        }
     }
