    using System;
    using Gtk;
    
    public partial class MainWindow : Gtk.Window
    {
    	public MainWindow() : base(Gtk.WindowType.Toplevel)
    	{
    		Build();
    		KeyPressEvent += KeyPress;
    	}
    
    	[GLib.ConnectBefore]
    	protected void KeyPress(object sender, KeyPressEventArgs args)
    	{
    		Console.WriteLine(args.Event.Key);
    	}
    
    	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    	{
    		KeyPressEvent -= KeyPress;
    		Application.Quit();
    		a.RetVal = true;
    	}
    }
