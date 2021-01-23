        using System;
    using System.Drawing;
    using System.Net;
    using System.Windows.Forms;
    using Framework.UserApplication.Utility;
    
    namespace Framework.UserApplication.CommonDialogs
    {
        /**************************************************************************************************
         * A TCP IP input mask.
         * sealed because of virtual member calls in constructor
         *  By having a virtual call in an object's constructor you are introducing the possibility that
         *  inheriting objects will execute code before they have been fully initialized.
         **************************************************************************************************/
    
        public sealed partial class TcpIpInputMaskType : UserControl
        {
            private bool _hasFocus; // True if this TcpIpInputMaskType has focus
    
            private IPAddress _ipAddress; // The IP address
            private bool _showFocusRect; // True to show, false to hide the focus rectangle
    
            /**************************************************************************************************
             * Default constructor.
             **************************************************************************************************/
    
            public TcpIpInputMaskType()
            {
                _showFocusRect = ShowFocusCues;
                _hasFocus = false;
                InitializeComponent();
                ChangeUICues += IpTextBoxes_ChangeUiCues;
                BackColor = Color.Transparent;
                AutoSize = true;
            }
    
            /**************************************************************************************************
             * Gets the IP address.
             *
             * @return  The IP address.
             **************************************************************************************************/
    
            public IPAddress IpAddress
            {
                get
                {
                    try
                    {
                        _ipAddress = new IPAddress(new[]
                        {
                            Convert.ToByte(IP1.Text), Convert.ToByte(IP2.Text),
                            Convert.ToByte(IP3.Text), Convert.ToByte(IP4.Text)
                        });
                    }
                    catch (Exception e)
                    {
                        _ipAddress = null;
                        Console.WriteLine(e);
                    }
    
                    return _ipAddress;
                }
            }
    
            /**************************************************************************************************
             * Gets the IP address hex string.
             *
             * @return  The IP hex address string.
             **************************************************************************************************/
    
            public string IpAddressHexString
            {
                get
                {
                    if (IpAddress == null)
                        return "";
    
                    var barry = new[]
                    {
                        Convert.ToByte(IP1.Text),
                        Convert.ToByte(IP2.Text),
                        Convert.ToByte(IP3.Text),
                        Convert.ToByte(IP4.Text)
                    };
                    return AsciiHexConversionType.ByteArrayToHexWithSpaces(barry);
                }
            }
    
            /**************************************************************************************************
             * Gets the dotted IP address string.
             *
             * @return  The dotted IP address string.
             **************************************************************************************************/
    
            public string DottedIpAddressString
            {
                get
                {
                    if (_ipAddress == null)
                        return "";
    
                    return IpAddress.ToString();
                }
            }
    
            /**************************************************************************************************
             * Gets the ulong IP address.
             *
             * @return  The ulong IP address.
             **************************************************************************************************/
    
            public ulong UlongIpAddress
            {
                get
                {
                    if (IpAddress == null)
                        return 0;
    
                    var address = (ulong) (Convert.ToByte(IP1.Text) * (256 ^ 3)) +
                                  (ulong) (Convert.ToByte(IP2.Text) * (256 ^ 2)) +
                                  (ulong) (Convert.ToByte(IP3.Text) * 256) + Convert.ToByte(IP4.Text);
                    return address;
                }
            }
    
            /**************************************************************************************************
             * Change focus.
             *
             * @param   ipTextBox   The IP control.
             **************************************************************************************************/
    
            private void ChangeFocus(TextBox ipTextBox)
            {
                switch (ipTextBox.Name)
                {
                    case "IP1":
                        IP2.Select();
                        break;
                    case "IP2":
                        IP3.Select();
                        break;
                    case "IP3":
                        IP4.Select();
                        break;
                    case "IP4":
                        ipTextBox.SelectNextControl(ActiveControl, true, true, true, true);
                        break;
                }
            }
    
            /**************************************************************************************************
             * Event handler. Called by IP1 for key press events.
             *
             * @param   sender  Source of the event.
             * @param   e       Key press event information.
             **************************************************************************************************/
    
            private void IP1_KeyPress(object sender, KeyPressEventArgs e)
            {
                var ipTextBox = sender as TextBox;
                switch (e.KeyChar)
                {
                    case '\r':
                        SendKeys.Send("{TAB}");
                        e.Handled = true;
                        return;
                    case '\t':
                        if (ipTextBox != null)
                            ChangeFocus(ipTextBox);
                        e.Handled = true;
                        break;
                    default:
                        if (!char.IsDigit(e.KeyChar))
                            e.Handled = true;
                        break;
                }
            }
    
            /**************************************************************************************************
             * Event handler. Called by IP1 for text changed events.
             *
             * @param   sender  Source of the event.
             * @param   e       Event information.
             **************************************************************************************************/
    
            private void IP1_TextChanged(object sender, EventArgs e)
            {
                var ipTextBox = sender as TextBox;
                if (ipTextBox != null && ipTextBox.TextLength == 4)
                {
                    ipTextBox.Text = ipTextBox.Text.Substring(0, 3);
                    return;
                }
    
                if (ipTextBox != null && ipTextBox.TextLength == 3)
                    ChangeFocus(ipTextBox);
            }
    
            /**************************************************************************************************
             * Event handler. Called by IP4 for key down events.
             *
             * @param   sender  Source of the event.
             * @param   e       Key event information.
             **************************************************************************************************/
    
            private void IP4_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
    
            /**************************************************************************************************
             * Event handler. Called by IpTextBoxes for change user interface cues events.
             *
             * @param   sender  Source of the event.
             * @param   e       User interface cues event information.
             **************************************************************************************************/
    
            private void IpTextBoxes_ChangeUiCues(object sender, UICuesEventArgs e)
            {
                _showFocusRect = e.ShowFocus;
            }
    
            /**************************************************************************************************
             * Raises the <see cref="E:System.Windows.Forms.Control.Enter" />
             *  event.
             *
             * @param   e   An <see cref="T:System.EventArgs" />
             *               that contains the event data.
             **************************************************************************************************/
    
            protected override void OnEnter(EventArgs e)
            {
                Invalidate();
            }
    
            /**************************************************************************************************
             * Raises the <see cref="E:System.Windows.Forms.Control.Leave" />
             *  event.
             *
             * @param   e   An <see cref="T:System.EventArgs" />
             *               that contains the event data.
             **************************************************************************************************/
    
            protected override void OnLeave(EventArgs e)
            {
                Invalidate();
            }
    
            /**************************************************************************************************
             * Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" />
             *  event.
             *
             * @param   e   An <see cref="T:System.EventArgs" />
             *               that contains the event data.
             **************************************************************************************************/
    
            protected override void OnLostFocus(EventArgs e)
            {
                _hasFocus = false;
            }
    
            /**************************************************************************************************
             * Raises the <see cref="E:System.Windows.Forms.Control.Paint" />
             *  event.
             *
             * @param   e   A <see cref="T:System.Windows.Forms.PaintEventArgs" />
             *               that contains the event data.
             **************************************************************************************************/
    
            protected override void OnPaint(PaintEventArgs e)
            {
                var focusRect = ClientRectangle;
                focusRect.Inflate(-2, -2);
                if (_hasFocus && _showFocusRect)
                    ControlPaint.DrawFocusRectangle(e.Graphics, focusRect, ForeColor, BackColor);
                else
                    e.Graphics.DrawRectangle(new Pen(BackColor, 1), focusRect);
                base.OnPaint(e);
            }
    
            /**************************************************************************************************
             * Sets default IP address.
             *
             * @param   ip1 The first IP.
             * @param   ip2 The second IP.
             * @param   ip3 The third IP.
             * @param   ip4 The fourth IP.
             *
             * @return  The IPAddress.
             **************************************************************************************************/
    
            public IPAddress SetDefaultIpAddress(string ip1, string ip2, string ip3, string ip4)
            {
                IP1.Text = ip1;
                IP2.Text = ip2;
                IP3.Text = ip3;
                IP4.Text = ip4;
                return IpAddress;
                }
            }
    
    }
