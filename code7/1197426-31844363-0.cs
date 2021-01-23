    namespace Whatever {
        public class MainWindow: Gtk.Window {
            public MainWindow()
                : base( Gtk.WindowType.Toplevel )
            {
                this.Title = "Gtk# App";
                this.Build();
            }
            private void Build() {
                // create your widgets
            }
    
            // more things...
    }
