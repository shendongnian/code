    var enumerable = DataStream();
    var enumeratorHasNext = enumerable.MoveNext();
    while (enumeratorHasNext)
    {
        var delimiter = enumerable.Current;
        using (var file = new StreamWriter(delimiter + ".txt"))
        {
            enumeratorHasNext = enumerable.MoveNext();
            while (enumeratorHasNext && !isDelimiterString(enumerable.Current))
            {
                file.WriteLine(enumerable.Current);
                enumeratorHasNext = enumerable.MoveNext();
            }
        }
    }
