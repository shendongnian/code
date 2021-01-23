    var pdv1 = isHandheld == true ? new PDVHH() : new PDV(); is considered a declaration-statement.
    //var pdv1 = isHandheld == true ? new PDVHH() : new PDV(); won't work but the following will
    // The above is the equivalent of the below statement which will NOT work.
    if (isHandheld)
          var pdv1 = new PDVHH();
    else
          var pdv1 = new PDV();
    if (isHandheld)
    {
        var pdv1 = new PDVHH();
    }
    else
    {
        var pdv1 = new PDV();
    }
