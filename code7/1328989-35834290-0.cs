    using System;
    using Gtk;
    
    public partial class MainWindow : Gtk.Window
    {
    	public MainWindow() : base(Gtk.WindowType.Toplevel)
    	{
    		Build();
    		KeyPressEvent += KeyPress;
    	}
    
    	protected void KeyPress(object sender, KeyPressEventArgs args)
    	{
    		if (args.Event.Key == Gdk.Key.Up)
    			return;
    		Console.WriteLine(args.Event.Key);
    	}
    
    	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    	{
    		KeyPressEvent -= KeyPress;
    		Application.Quit();
    		a.RetVal = true;
    	}
    }
