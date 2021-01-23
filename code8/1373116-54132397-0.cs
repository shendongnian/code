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
    [Benchmark]
    public void Heap()
    {
        using (var provider = new RNGCryptoServiceProvider())
        {
            var bytes = new byte[16];
            provider.GetBytes(bytes);
            new Guid(bytes);
        }
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
|   Heap | 166.9 ns | 1.8517 ns | 1.7320 ns |      0.0207 |           - |           - |                88 B |
|   Fill | 124.3 ns | 0.8265 ns | 0.7731 ns |           - |           - |           - |                   - |
