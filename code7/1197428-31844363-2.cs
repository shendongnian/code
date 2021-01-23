    namespace Whatever {
    	public class DlgMoreInfo : Gtk.Dialog {
    		public DlgMoreInfo(Gtk.Window parent) {
    			this.Build();
    			
    			this.Title = parent.Title + " more info";
    			this.Icon = parent.Icon;
    			this.Parent = parent;
    			this.TransientFor = parent;
    			this.SetPosition( Gtk.WindowPosition.CenterOnParent );
                this.ShowAll();
            }
        
            private void Build() {
                // Create widgets here...
                // Buttons
		 	    this.AddButton( Gtk.Stock.Cancel, Gtk.ResponseType.Cancel );
			    this.AddButton( Gtk.Stock.Ok, Gtk.ResponseType.Ok );
			    this.DefaultResponse = Gtk.ResponseType.Ok;
            }
        }
    }
