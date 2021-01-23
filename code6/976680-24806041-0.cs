     WordServiceApplicationProxy proxy =
                                (WordServiceApplicationProxy)
                                    SPServiceContext.GetContext(SPContext.Current.Web.Site)
                                        .GetDefaultProxy(typeof (WordServiceApplicationProxy));
    
                            ConversionJob job = new ConversionJob(proxy); //, jobSettings);
