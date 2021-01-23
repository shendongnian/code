    public class MainForm : Form, ITerminal0View
    {
        ...
        #region Terminal 0 methods implementation
        
        void ITerminal0View.ClearText(){...}
        void ITerminal0View.ShowLines(String[] values){...}
        void ITerminal0View.DisableButtons(){...} 
        #endregion
