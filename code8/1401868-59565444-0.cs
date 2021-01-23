csharp
const string sid = "3f72497b-188f-4d3a-92a1-c7432cfae62a";
static readonly Guid guid = new Guid(sid);
static void Main()
{
    Guid gid = Guid.NewGuid(); // As an example, say this comes from the db
    Measure(() => (gid.ToString().ToLower() == sid.ToLower()));
    // result: 177 ms
    Measure(() => (gid == new Guid(sid)));
    // result: 113 ms
    Measure(() => (gid == guid));
    // result: 6 ms
    Measure(() => (gid == Guid.Parse(sid)));
    // result: 114 ms
    Measure(() => (gid.Equals(sid)));
    // result: 7 ms
}
// Define other methods and classes here
public static void Measure<T>(Func<T> func)
{
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    for (int i = 1; i < 1000000; i++)
    {
        T result = func();
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
}
So if you can't store your guid in a constant, the built in Guid.Equals() is your preferred option.
