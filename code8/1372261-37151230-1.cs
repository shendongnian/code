    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using GrimoireDevelopmentKit.DevelopmentKit.UserInterface;
    using GrimoireTactics.Framework.OpenGL.Modeling;
    using GrimoireTactics.Framework.OpenGL.Texturing;
    using GrimoireTactics.Framework.Security;
    
    namespace GrimoireDevelopmentKit.DevelopmentKit
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new DevelopmentKitEditor());
    
                Obfuscator obs = new Obfuscator("My Arbitary Seed");
                byte[] obufsicatedData = obs.Encrypt("Some Top Secret Data");
                byte[] unobufsicatedData = obs.Decrypt(obufsicatedData);
                Console.WriteLine(obs.GetString(unobufsicatedData));
                Console.Read();
            }
        }
    }
