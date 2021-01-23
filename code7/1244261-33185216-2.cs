        [NonEvent]
        public void ApplicationStarting()
        {
            if (this.IsEnabled(EventLevel.Verbose, Keywords.Application))
            {
                this.ApplicationStartingImplementation();
            }
        }
        [Event(100, Level = EventLevel.Verbose, Keywords = Keywords.Application, Task = Tasks.Initialize, Opcode = Opcodes.Starting, Version = 1)]
        private void ApplicationStartingImplementation()
        {
            this.WriteEvent(100);
        }
