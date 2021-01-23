    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;
    
    namespace WpfApplication1 {
        class Program {
            [STAThread]
            public static void Main(string[] args) {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Start();
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void Start() {
                var app = new App();
                app.Run(new MainWindow());
            }
            private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
                // etc..
            }
        }
    
        public class App : Application {
            // etc..
        }
    }
