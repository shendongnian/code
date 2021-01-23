`
for (int i = 0; i < 300; i++)
{
    Task.Run(() => {
        var x = ComputeStuff(datavector, i); // value of i was incorrect
        var y = ComputeMoreStuff(x);
        // ...
    });
}
`
I got this to work by changing the outer iterator and localizing its value with a gate.
`
for (int ii = 0; ii < 300; ii++)
{
    System.Threading.CountdownEvent handoff = new System.Threading.CountdownEvent(1);
    Task.Run(() => {
        int i = ii;
        handoff.Signal();
        var x = ComputeStuff(datavector, i);
        var y = ComputeMoreStuff(x);
        // ...
 
    });
    handoff.Wait();
}
