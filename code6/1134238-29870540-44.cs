        public class InitialTerminalContext : ITerminalContext
        {
             private ITerminalContext[] terminalContexts;
             public InitialTerminalContext(ITerminalContext[] terminalContexts)
             {
                  if (terminalContexts == null) throw new ArgumentNullException();
                  
                  this.terminalContexts = terminalContexts;
                  // Not the best approach(giving this inside the constructor) but for sake of simplicity...
                  foreach(var context in terminalContexts) {context.Parent = this;}
             }
             public ITerminalContext this[Int32 index]
             {
                 get
                 {
                      return this.terminalContexts[index];
                 }
             }
        }
       
