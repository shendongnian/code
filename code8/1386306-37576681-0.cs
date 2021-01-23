    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Gma.UserActivityMonitor;
    using System.Windows.Input;
    using System.Windows.Forms;
    namespace WpfApplicationTest
    {
    public class HookManager
    {
        private GlobalEventProvider _provider;
        public event EventHandler<HookKeyArgs> KeyDown;
        public event EventHandler<HookKeyArgs> KeyUp;
        public HookManager()
        {
            _provider = new Gma.UserActivityMonitor.GlobalEventProvider();
            _provider.KeyDown += _provider_KeyDown;
            _provider.KeyUp += _provider_KeyUp;
        }
        void _provider_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (KeyUp != null)
            {
                KeyUp(this, new HookKeyArgs(convertWinFormsKey(e.KeyData), false, true));
            }
        }
        void _provider_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
 	        if (KeyDown != null)
            {
                KeyDown(this, new HookKeyArgs(convertWinFormsKey(e.KeyData), true, false));
            }
        }
        System.Windows.Input.Key convertWinFormsKey(System.Windows.Forms.Keys keyMeta)
        {
            Keys formsKey = keyMeta;
            return KeyInterop.KeyFromVirtualKey((int)formsKey);
        }
    }
    public class HookKeyArgs : EventArgs
    {
        public System.Windows.Input.Key KeyPressed {get; private set;}
        public bool IsDown { get; private set; }
        public bool IsUp { get; private set; }
        public HookKeyArgs(System.Windows.Input.Key keyPressed, bool isDown, bool isUp)
        {
            this.KeyPressed = keyPressed;
            this.IsDown = isDown;
            this.IsUp = isUp;
        }
    }}
