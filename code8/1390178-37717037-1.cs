    // First case.
    new[] { new Lazy<bool>(() => foo == true), new Lazy<bool>(() => bar == false) }.
        If(checks => checks[0].Value || checks[1].Value, checks => {
        if (checks[0].Value) {
            //foo is true
        }
        if (!checks[1].Value) {
            //bar is false
        }
    });
    // Second case.
    new[] { "bar" }.If(variables => (string)variables[0] == "bar", variables => {
        //we now have the runtime generated variable.
    });
