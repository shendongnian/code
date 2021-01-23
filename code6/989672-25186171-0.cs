    public static IObservable<string> ToString(this IEnumerable<IObservable<string>> observables, string start, string separator, string stop)
    {
        return observables.CombineLatest()
                          .Select(values =>
                          {
                              var sb = new StringBuilder(start);
                              var first = true;
                              foreach (var value in values)
                              {
                                  if (first)
                                      first = false;
                                  else
                                      sb.Append(separator);
                                  sb.Append(value);
                              }
                              sb.Append(stop);
                              return sb.ToString();
                          });
    }
