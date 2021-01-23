        [NonEvent]
        public void ApplicationStarting()
        {
            if (this.IsEnabled(EventLevel.Verbose, Keywords.Application))
            {
                this.ApplicationStarting(100);
            }
        }
        [Event(100, Level = EventLevel.Verbose, Keywords = Keywords.Application, Task = Tasks.Initialize, Opcode = Opcodes.Starting, Version = 1)]
        private void ApplicationStarting()
        {
            this.WriteEvent(100);
        }
