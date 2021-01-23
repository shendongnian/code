    var admissionObservable = Observable
         .FromEventPattern<StudentAdmittedEventArgs>(school, "StudentAdmitted")
         .Timestamp();        
    admissionObservable
        .Zip(admissionObservable.Skip(1), (a, b) => Tuple.Create(a,b))        
        .Where(pair => pair.Item2.Timestamp - pair.Item1.Timestamp <= timeSpan)        
        .Select(pair => new JoiningData
        {
            Students = Tuple.Create(pair.Item1.Value.EventArgs.Student, pair.Item2.Value.EventArgs.Student),
            School = pair.Item1.Value.EventArgs.School,
            Interval = pair.Item2.Timestamp - pair.Item1.Timestamp
        });
