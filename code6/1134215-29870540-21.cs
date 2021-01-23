    public class Terminal0Context : ITerminalContext
    {
        private ITerminal0View view;
        public Terminal0Context(ITerminal0Viewview)
	    {
            this.view = view;
	    }
  
        public ITerminalContext Parent {get; set;}
        public ITerminalContext DoBtn1() 
        {
            this.view.ClearText();
            this.view.ShowLines(lines);
            return this;
        }
        public ITerminalContext DoBtn_End() 
        {
            this.view.ClearText();
            this.view.ShowLines(otherLines);
            return this.Parent;
        }
    }
