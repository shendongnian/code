    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            //...
            setHandler(button1);
            setHandler(button2);
            //...
        }
    
        protected void setHandler(Button btn)
        {
            // TODO: synchronise thread & remove old handler
            /**
             * e.g.:
             * lock(_eLock){
             *   btn.MouseMove -= new MouseEventHandler(..)
             *   btn.MouseMove += new MouseEventHandler(..)
             * }
             * 
             */
    
            // NOTE: the 'AllowDrop' property only for example - 
            //       you can replace this with your custom components - e.g. ButtonCustom()
            /**
             * public class ButtonCustom: Button
             * {
             *    ...
             *    bool AllowMove { get; set; }
             *    ...
             * }
             * 
             */
    
            btn.AllowDrop = false;
    
            btn.MouseMove += new MouseEventHandler((object sender, MouseEventArgs e) => {
                if(!btn.AllowDrop) {
                    return;
                }
                btn.Location = this.PointToClient(Cursor.Position);
            });
    
            btn.MouseDown += new MouseEventHandler((object sender, MouseEventArgs e) => {
                btn.AllowDrop = true;
            });
    
            btn.MouseUp += new MouseEventHandler((object sender, MouseEventArgs e) => {
                btn.AllowDrop = false;
            });
        }
    }
