    public class ExecuteScript: IExecuteScript
    {
        public void Execute()
        {
            System.Diagnostics.Process.Start("yourscript");
        }
    }
