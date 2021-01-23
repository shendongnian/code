    public static void ModifyLabelFont(this Gtk.Button button, string fontDescription)
    {
        foreach(Widget child in button.AllChildren)
        {
            if(child.GetType() != (typeof(Gtk.Alignment)))
                continue;
            foreach(Widget grandChild in ((Gtk.Alignment)child).AllChildren)
            {
                if(grandChild.GetType() != (typeof(Gtk.HBox)))
                    continue;
                foreach(Widget greatGrandChild in ((Gtk.HBox)grandChild).AllChildren)
                {
                    if(greatGrandChild.GetType() != (typeof(Gtk.Label)))
                        continue;
                    string text = ((Gtk.Label)greatGrandChild).Text;
                    ((Gtk.HBox)grandChild).Remove(greatGrandChild);
                    Label label = new Label(text);
                    label.ModifyFont(FontDescription.FromString(fontDescription));
                    label.Show();
                    ((Gtk.HBox)grandChild).Add(label);
                }
            }                    
        }
    }
