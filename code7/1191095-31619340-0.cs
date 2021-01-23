    using System;
    using System.Threading;
    using Akka.Actor;
    
    namespace ProcessActors
    {
        class Program
        {
            /// <summary>
            /// Top-level process coordinator actor.
            /// </summary>
            public class ProcessesCoordinatorActor : ReceiveActor
            {
                public ProcessesCoordinatorActor()
                {
                    Receive<CreateChildActor>(createRequest =>
                    {
                        Console.WriteLine("{0} creating child actor: {1}", Self.Path, createRequest.ChildName);
    
                        var child = Context.ActorOf(createRequest.ChildProps, createRequest.ChildName);
                        if (createRequest.ActorToNotify != null)
                            createRequest.ActorToNotify.Tell(new ReadyForWork(child));
                    });
    
                    Receive<ReadyForWork>(ready =>
                    {
                        Console.WriteLine("Coordinator sees worker ready: {0}", ready.Worker.Path);
                    });
    
                    ReceiveAny(o =>
                    {
                        Console.WriteLine("{0} received {1}", Self.Path, o);
                    });
    
                }
            }
    
            /// <summary>
            /// Actor for a given process.
            /// </summary>
            public class ProcessActor : ReceiveActor
            {
                public ProcessActor()
                {
                    Receive<CreateChildActor>(createRequest =>
                    {
                        Console.WriteLine("{0} creating child actor: {1}", Self.Path, createRequest.ChildName);
    
                        var child = Context.ActorOf(createRequest.ChildProps, createRequest.ChildName);
                        if (createRequest.ActorToNotify != null)
                            createRequest.ActorToNotify.Tell(new ReadyForWork(child));
                    });
    
                    ReceiveAny(o =>
                    {
                        Console.WriteLine("{0} received {1}", Self.Path, o);
                    });
                }
            }
    
            /// <summary>
            /// Marker interface for sub-processes.
            /// </summary>
            public class SubprocessActor : ReceiveActor
            {
                public SubprocessActor()
                {
                    ReceiveAny(o =>
                    {
                        Console.WriteLine("{0} received {1}", Self.Path, o);
                    });
                }
            }
    
            public static void Main(string[] args)
            {
                using (var system = ActorSystem.Create("MyActorSystem"))
                {
    
                    Console.WriteLine("Starting up.");
    
                    var coordinator = system.ActorOf(Props.Create(() => new ProcessesCoordinatorActor()), "processes");
                    var processProps = Props.Create(() => new ProcessActor());
    
                    // create process actors
                    coordinator.Tell(new CreateNewProcess("process1", processProps));
                    coordinator.Tell(new CreateNewProcess("process2", processProps));
                    coordinator.Tell(new CreateNewProcess("process3", processProps));
    
                    var subprocessProps = Props.Create(() => new SubprocessActor());
    
                    // tiny sleep to let everything boot
                    Thread.Sleep(TimeSpan.FromMilliseconds(50));
    
                    // get handle to an actor somewhere down in the hierarchy
                    var process1 = system.ActorSelection("/user/processes/process1").ResolveOne(TimeSpan.FromSeconds(1)).Result;
    
                    // create subprocess of process1 and notify the coordinator of new subprocess actor
                    process1.Tell(new CreateNewSubprocess("subprocess1", subprocessProps, coordinator));
    
                    Console.ReadLine();
                }
            }
    
            #region Messages
            /// <summary>
            /// Command to create ChildProps actor and notify another actor about it.
            /// </summary>
            public class CreateChildActor
            {
                public CreateChildActor(string childName, Props childProps, IActorRef actorToNotify)
                {
                    ChildName = childName;
                    ActorToNotify = actorToNotify;
                    ChildProps = childProps;
                }
    
                public CreateChildActor(string childName, Props childProps)
                    : this(childName, childProps, null)
                {
                }
    
                public Props ChildProps { get; private set; }
                public string ChildName { get; private set; }
                public IActorRef ActorToNotify { get; private set; }
            }
    
            public class CreateNewProcess : CreateChildActor
            {
                public CreateNewProcess(string childName, Props childProps, IActorRef actorToNotify)
                    : base(childName, childProps, actorToNotify)
                {
                }
    
                public CreateNewProcess(string childName, Props childProps)
                    : this(childName, childProps, null)
                {
                }
            }
    
            public class CreateNewSubprocess : CreateChildActor
            {
                public CreateNewSubprocess(string childName, Props childProps, IActorRef actorToNotify)
                    : base(childName, childProps, actorToNotify)
                {
                }
    
                public CreateNewSubprocess(string childName, Props childProps)
                    : this(childName, childProps, null)
                {
                }
            }
    
            /// <summary>
            /// Marker interface for actor to report to external context when ready.
            /// </summary>
            public class ReadyForWork
            {
                public ReadyForWork(IActorRef worker)
                {
                    Worker = worker;
                }
    
                public IActorRef Worker { get; private set; }
            }
    
            #endregion
    
        }
    }
