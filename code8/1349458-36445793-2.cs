    IEnumerable<int> numbers = Enumerable.Range(0, 10);
    IEnumerable<int> evenNumbers = numbers
        .ToObservable()
        .SelectMany(async i => new { Value = i, IsMatch = await IsEven(i) })
        .Where(a => a.IsMatch)
        .Select(a => a.Value)
        .ToEnumerable();
    async Task<bool> IsEven(int i)
    {
        await Task.Delay(100);
        return i % 2 == 0;
    }
