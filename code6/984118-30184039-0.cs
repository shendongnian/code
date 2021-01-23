                                             AggregationDescriptor<object> v = new AggregationDescriptor<object>();
                                             v.Terms("a", tr =>
                                          {
                                              TermsAggregationDescriptor<object> trmAggDescriptor = new TermsAggregationDescriptor<object>();
                                              trmAggDescriptor.Field("a");
                                              trmAggDescriptor.Size(0);
                                              return trmAggDescriptor;
                                          });
                                             return v;
                                         }));
            var terms1 = qryRes1.Aggs.Terms("a");`
