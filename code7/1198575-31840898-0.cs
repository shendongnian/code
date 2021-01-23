    vbVal = form["filter1"]; {"North America"}
    qryResults = qryResults.Where (w=>w.col1 == vbVal);
    vbVal = form["filter2"]; {"USA"}
    qryResults = qryResults.Where (w=>w.col2 == vbVal);
    vbVal = form["filter3"]; {"New York"}
    qryResults = qryResults.Where (w=>w.col2 == vbVal);
