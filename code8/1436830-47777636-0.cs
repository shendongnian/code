    public class PowerShellHelper
    {
        public void Execute(string command)
        {
            using (var ps = PowerShell.Create())
            {
                var results = ps.AddScript(command).Invoke();
                foreach (var result in results)
                {
                    Debug.Write(result.ToString());
                }
            }
        }
    }
