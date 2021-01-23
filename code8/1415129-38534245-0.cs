    using System;
    using System.Security.Permissions;
    using System.Windows.Forms;
    
    namespace TaskKillTestApp
    {
        static class Program
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            private class TestMessageFilter : IMessageFilter
            {
                public bool PreFilterMessage(ref Message m)
                {
                    if (m.Msg == /*WM_CLOSE*/ 0x10)
                    {
                        Application.Exit();
                        return true;
                    }
                    return false;
                }
            }
    
            [STAThread]
            static void Main()
            {
                Application.AddMessageFilter(new TestMessageFilter());
                Application.Run();
            }
        }
    }
