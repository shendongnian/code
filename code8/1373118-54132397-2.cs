c#
public static Guid CreateCryptographicallySecureGuid()
{
    Span<byte> bytes = stackalloc byte[16];
    RandomNumberGenerator.Fill(bytes);
    return new Guid(bytes);
}
I created a benchmark comparing this to the accepted answer.
c#
[MemoryDiagnoser]
public class Test
{
    private static readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
    [Benchmark]
    public void Heap()
    {
        var bytes = new byte[16];
        _rng.GetBytes(bytes);
        new Guid(bytes);
    }
    [Benchmark]
    public void Fill()
    {
        Span<byte> bytes = stackalloc byte[16];
        RandomNumberGenerator.Fill(bytes);
        new Guid(bytes);
    }
}
	| Method |     Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
	|------- |---------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
	|   Heap | 128.8 ns | 0.6386 ns | 0.5973 ns |      0.0093 |           - |           - |                40 B |
	|   Fill | 117.2 ns | 0.3901 ns | 0.3458 ns |           - |           - |           - |                   - |
