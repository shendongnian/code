    var source = "junk{Hello}junk{World}junk".ToObservable();
    var messages = source
        .Publish(o =>
        {
            return o.Buffer(
                o.Where(c => c == '{'),
                _ => o.Where(c => c == '}'));
        })
        .Select(buffer => new string(buffer.ToArray()));
    messages.Subscribe(x => Console.WriteLine(x));
    Console.ReadLine();
