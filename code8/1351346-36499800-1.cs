    try {
        Int32.Parse(string);
    } catch (System.OverflowException e) {
        // do stuff
    }
    // be sure to catch all other possible exceptions here
