    var qryRes1 = client.Search<object>(x => x
                        .Aggregations(ag => ag
                               .Filter("filter", (flt => flt
                                   .Filter(f =>
                                   {
                                       FilterContainer filter = null;
                                        filter &= f.Query(qr => qr.Term(wl => wl.OnField("a").Value("the value you need to filter for field a")));
                                       return filter;
                                   })
                                          .Aggregations(agr => agr
                                           .Terms("b", tr =>
                                           {
                                               TermsAggregationDescriptor<object> trmAggDescriptor = new TermsAggregationDescriptor<object>();
                                               trmAggDescriptor.Field("b");
                                               
                                               return trmAggDescriptor;
                                           }))))
                             ));
            var terms = qryRes1.Aggs.Filter("filter").Terms("b");
