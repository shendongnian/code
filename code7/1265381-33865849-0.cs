    using Gma.System.MouseKeyHook;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Rapid_Fire
    {
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendInput(int nInputs, ref INPUT pInputs, int cbSize);
        #region structs
        /// <summary>
        /// Structure for SendInput function holding relevant mouse coordinates and information
        /// </summary>
        public struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        };
        /// <summary>
        /// Structure for SendInput function holding coordinates of the click and other information
        /// </summary>
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        };
        #endregion
        public const int INPUT_MOUSE = 0x0000;
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int TIMES_CLICK_FIRE = 25;
        private bool m_fire = false;
        private INPUT m_input = new INPUT();
        private IKeyboardMouseEvents m_Events;
        public Form1()
        {
            InitializeComponent();
            SubscribeGlobal();
            InitAutoClick();
            this.FormClosed += new FormClosedEventHandler(formClosed);
        }
        private void SubscribeGlobal()
        {
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
        }
        private void Subscribe(IKeyboardMouseEvents events)
        {
            m_Events = events;
            m_Events.MouseUp += OnMouseUp;
            m_Events.MouseDown += OnMouseDown;
        }   
        private void InitAutoClick()
        {
            m_input.type = INPUT_MOUSE;
            m_input.mi.dx = 0;
            m_input.mi.dy = 0;
            m_input.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            m_input.mi.dwExtraInfo = IntPtr.Zero;
            m_input.mi.mouseData = 0;
            m_input.mi.time = 0;
        }
        private void Log(string text)
        {
            if (IsDisposed) return;
            Console.WriteLine(text);
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            m_fire = true;
            Thread thread = new Thread(RapidFire);
            thread.Start();
        }
        private void RapidFire()
        {
            while (m_fire)
            {
                for (; ; )
                {
                    ClickLeftMouseButtonSendInput();
                }
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            m_fire = false;
        }
        private void ClickLeftMouseButtonSendInput()
        {
            SendInput(1, ref m_input, Marshal.SizeOf(m_input));
            m_input.mi.dwFlags = MOUSEEVENTF_LEFTUP;
            SendInput(1, ref m_input, Marshal.SizeOf(m_input));
        }
        private void formClosed(object sender, FormClosedEventArgs e)
        {
            Unsubscribe();
        }
        private void Unsubscribe()
        {
            if (m_Events == null) return;
            m_Events.MouseUp -= OnMouseUp;
            m_Events.MouseDown -= OnMouseDown;
            m_Events.Dispose();
            m_Events = null;
        }
    }
    }
