    var ns = XNamespace.Get("url");        
    XDocument requestXMl = new XDocument(
        new XElement(ns+"WEB_REQUEST",
            new XElement(ns+"HTTP_HEADER_INFORMATION",
                new XElement(ns+"DEFINED_HEADERS",
                    new XElement(ns+"HTTP_DEFINED_REQUEST_HEADER",
                            new XElement(ns+"ItemNameType", "RequestDate"),
                            new XElement(ns+"ItemValue", _currentTime)
                                ),
                        new XElement(ns+"HTTP_DEFINED_REQUEST_HEADER",
                            new XElement(ns+"ItemNameType", "AuthorizationValue"),
                            new XElement(ns+"ItemValue", credentials)
                                )
                              )
                           ),
            new XElement(ns + "COLL",
                new XElement(ns + "TID", _t),
                new XElement(ns + "SID", _s)
                        )
                    )
            );
