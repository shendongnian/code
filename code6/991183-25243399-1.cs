    public class IPAddressView
    {
        public enum ButtonType
        {
            Router,
            Switch,
            Steelhead,
            InPath,
            Server,
            NCAP
        }
        public FlowLayoutPanel FlowPanel {get; private set; }
        public Label Address { get; private set; }
        public Button Router { get; private set; }
        public Button Switch { get; private set; }
        public Button Steelhead { get; private set; }
        public Button InPath { get; private set; }
        public Button Server { get; private set; }
        public Button NCAP { get; private set; }
    
        public IPAddressView(string address)
        {          
                    
            FlowPanel = new FlowLayoutPanel();
            Address = new Label() { Text = address };
            Router = new Button();
            Switch = new Button();
            Steelhead = new Button();
            InPath = new Button();
            Server = new Button();
            NCAP = new Button();
    
            Router.Click += (s, e) => { OnButtonClicked(ButtonType.Router); };
            Switch.Click += (s, e) => { OnButtonClicked(ButtonType.Switch); };
            Steelhead.Click += (s, e) => { OnButtonClicked(ButtonType.Steelhead); };
            InPath.Click += (s, e) => { OnButtonClicked(ButtonType.InPath); };
            Server.Click += (s, e) => { OnButtonClicked(ButtonType.Server); };
            NCAP.Click += (s, e) => { OnButtonClicked(ButtonType.NCAP); };
    
            FlowPanel.Controls.AddRange(new Control[] { Address, Router, Switch, Steelhead, InPath, Server, NCAP });
        }
                          
        public delegate void ButtonClickedHandler(object sender, ButtonType type);
        public event ButtonClickedHandler ButtonClicked;
        private void OnButtonClicked(ButtonType type)
        {
            if (ButtonClicked != null)
            {
                ButtonClicked(this, type);
            }
        }         
    }
