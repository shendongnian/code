    public class ServerConnectionTools // Class 2
    {
        private caller m_serverCB;
        private ManagementScope m_scope;
    
    public ServerConnectionTools(caller par_serverCB)
        {
            m_serverCB = par_serverCB;
        this.Scope = InitiateScope();
        try
        {
           
            this.UpdateServicesList();
           
        }
        catch (System.Runtime.InteropServices.COMException)
        {
            // Server is unavailable
            Console.WriteLine("Unable to reach server {0}", server.ServerName);
        }
    }
