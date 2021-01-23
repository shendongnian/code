    public partial class Hotkey : TextBox
	{
		public Hotkey()
		{
			base.SetStyle(ControlStyles.UserPaint
						   | ControlStyles.StandardClick
						   | ControlStyles.StandardDoubleClick
						   | ControlStyles.UseTextForAccessibility, false);
			base.SetStyle(ControlStyles.FixedHeight, true);
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			e.Handled = true;
			Text = KeysToString(e.KeyData);
			
		}
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			e.Handled = true;
			if ((internalKeyData & ~(Keys.Control | Keys.Alt | Keys.Shift)) == Keys.None)
				Text = "";
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			e.Handled = true;
		}
		string KeysToString(Keys k)
		{
			string text = "";
			internalKeyData = Keys.None;
			if ((k & Keys.Shift) == Keys.Shift)
			{
				k &= ~Keys.Shift;
				text += "Shift + ";
				internalKeyData |= Keys.Shift;
			}
			if ((k & Keys.Alt) == Keys.Alt)
			{
				k &= ~Keys.Alt;
				text += "Alt + ";
				internalKeyData |= Keys.Alt;
			}
			if ((k & Keys.Control) == Keys.Control)
			{
				k &= ~Keys.Control;
				text += "Ctrl + ";
				internalKeyData |= Keys.Control;
			}
			if (k != Keys.ControlKey && k != Keys.ShiftKey && k != Keys.Menu)
			{
				text += ResolveToAlias(k);
				internalKeyData |= k;
			}
			if (text == "")
				text = "None";
			return (text);
		}
		string ResolveToAlias(Keys k)
		{
			if (k == Keys.Next)
				return ("PageDown");
			else if (k >= Keys.D0 && k <= Keys.D9)
				return ((k - Keys.D0).ToString());
			else if (k.ToString().Contains("Oem"))
				return (ToAscii(k).ToString());
			return (k.ToString());
		}
		Keys internalKeyData;
		public Keys KeyData
		{
			get { return (internalKeyData); }
			set { Text = KeysToString(value); }
		}
		public static char ToAscii(Keys key)
		{
			var outputBuilder = new StringBuilder(2);
			int result = ToAscii((uint)key, 0, new byte[256], outputBuilder, 0);
			if (result == 1)
				return outputBuilder[0];
			else
				throw new Exception("Invalid key");
		}
		[DllImport("user32.dll")]
		private static extern int ToAscii(uint uVirtKey, uint uScanCode,
										  byte[] lpKeyState,
										  [Out] StringBuilder lpChar,
										  uint uFlags);
	}
