    using System;
    using Akka.Actor;
    using Akka.Configuration;
    namespace DashBoard
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
		        port = 0
		        hostname = localhost
            }
        }
    }
    ");
                using (var system = ActorSystem.Create("Dashboard", config))
                {
                    var server = system.ActorSelection("akka.tcp://WorkerApp@localhost:8081/user/WorkerAppActor");
                    while (true)
                    {
                        var input = Console.ReadLine();
                        server.Tell(input);
                    }
                }
            }
        }
    }
	
