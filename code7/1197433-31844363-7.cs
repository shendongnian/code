    namespace Whatever {
        public class MainWindow: Gtk.Window {
            // ...more things
            private void OnWhatever() {
                var dlg = new DlgMoreInfo( this );
    
                if ( ( (Gtk.ResponseType) dlg.Run() ) == Gtk.ResponseType.Ok ) {
                    // do whatever here...
                }
    
                dlg.Destroy();
            }
        }
    }
