    using System;
    using Akka.Actor;
    using Akka.Configuration;
    namespace WorkerApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var config = ConfigurationFactory.ParseString(@"
    akka {  
        actor {
            provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
        }
        remote {
            helios.tcp {
                transport-class = ""Akka.Remote.Transport.Helios.HeliosTcpTransport, Akka.Remote""
                applied-adapters = []
                transport-protocol = tcp
                port = 8081
                hostname = localhost
            }
        }
    }
    ");
                using (var system = ActorSystem.Create("WorkerApp", config))
                {
                    system.ActorOf<WorkerAppActor>("WorkerAppActor");
                    Console.ReadLine();
                }
            }
        }
        class WorkerAppActor : TypedActor, IHandle<string>
        {
            public void Handle(string message)
            {
                Console.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
