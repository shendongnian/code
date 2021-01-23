        using System.Collections.Generic; //Above your namespace
        using System.Windows.Forms; //Above your namespace
    
        public partial class HostForm : Form, IHost
        {
            public View CurrentView { get; private set; }
    
            public HostForm()
            {
                InitializeComponent();
                SwitchView("UserLabel");
            }
    
            public void SwitchView(string name)
            {
                Controls.Remove(CurrentView);
                CurrentView = CreateViewFromName(name);
                Controls.Add(CurrentView);
                CurrentView.Show();
            }
    
            private View CreateViewFromName(string name)
            {
                switch (name.ToLowerInvariant())
                {
                    case "userlabel":
                        return new UserLabel(this);
                    case "usertext":
                        return new UserText(this);
                }
                throw new KeyNotFoundException("Could not find a form with that name!");
            }
        }
