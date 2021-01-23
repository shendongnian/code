    var requestCustomer = new GetCustomersByIdentifierRequest
    {
    Metadata =
                                  new CustomerSearchRetrieveReference
                                  .RequestMetadata
                                  {
                                      SecurityAction
                                              = "Get",
                                      UserId =
                                              "WebService"
                                  },
    Params =
                                  new GetCustomersByIdentifierParams
                                  {
                                      EffectiveAsOf
                                              =
                                              DateTime
                                              .Today,
                                      Identifiers
                                              =
                                              resultSearch
                                              .Select
                                              (
                                                  x
                                                  =>
                                                  x
                                                      .CustomerUd)
                                              .ToList
                                              (
                                                  )
                                  }
    };
