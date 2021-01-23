    static class Program {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main() {
               GUIThreadDispatcher.Instance.Init();  //setup the ability to use the GUI Thread when needed via a static reference
               Application.Run(new MainForm());
            }
        }
