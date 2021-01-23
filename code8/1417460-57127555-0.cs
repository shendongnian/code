using System;
using Microsoft.Owin.Hosting;
using Mono.Unix;
using Mono.Unix.Native;
public class Program
{
    public static void Main(string[] args)
    {
        string baseAddress = "http://localhost:9000/"; 
        // Start OWIN host 
        using (WebApp.Start<Startup>(url: baseAddress)) 
        { 
            Console.ReadLine(); 
        }
        if (IsRunningOnMono())
        {
            var terminationSignals = GetUnixTerminationSignals();
            UnixSignal.WaitAny(terminationSignals);
        }
        else
        {
            Console.ReadLine();
        }
        host.Stop();
    }
    public static bool IsRunningOnMono()
    {
        return Type.GetType("Mono.Runtime") != null;
    }
    public static UnixSignal[] GetUnixTerminationSignals()
    {
        return new[]
        {
            new UnixSignal(Signum.SIGINT),
            new UnixSignal(Signum.SIGTERM),
            new UnixSignal(Signum.SIGQUIT),
            new UnixSignal(Signum.SIGHUP)
        };
    }
}
full source blog post: 
https://dusted.codes/running-nancyfx-in-a-docker-container-a-beginners-guide-to-build-and-run-dotnet-applications-in-docker
