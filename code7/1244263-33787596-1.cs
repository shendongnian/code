    [Event(100, Level = EventLevel.Verbose, Keywords = Keywords.Application, Task = Tasks.Initialize, Opcode = Opcodes.Starting, Version = 1)]
    public void ApplicationStarting()
    {
        this.WriteEvent(100);
    }
