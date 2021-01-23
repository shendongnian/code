    Regex.Matches(text, pattern, RegexOptions.Multiline)
         .OfType<Match>()
         .Select (mt => new CallLog()
                        {
                            Time    = mt.Groups["Time"].Value,
                            Message = mt.Groups["Message"].Value
                        })
         .Aggregate(new ObservableCollection<CallLog>(),
                    (collection, log) => { collection.Add(log); return collection;} )
