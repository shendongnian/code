    public class TimePicker : MaskedTextBox {
    
    	String TimeFormat = null;
    	int[] maxs = null;
    	public TimePicker() {
    		this.Mask = "99:99:99.999";
    		maxs = new [] { 24, 60, 60, 1000 };
    		TimeFormat = "HH:mm:ss.fff";
    		this.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
    		this.CutCopyMaskFormat = MaskFormat.IncludePromptAndLiterals;
    		this.PromptChar = '0';
    		this.InsertKeyMode = InsertKeyMode.Overwrite;
    	}
    
    	[DllImport("user32.dll")]
    	static extern bool GetCaretPos(out Point lpPoint);
    
    	[DllImport("user32.dll")]
    	static extern bool SetCaretPos(int X, int Y);
    
    	bool isValidating = false;
    	protected override void OnTextChanged(EventArgs e) {
    		base.OnTextChanged(e);
    		if (isValidating || PromptChar != '0')
    			return;
    
    		Point p = Point.Empty;
    		GetCaretPos(out p);
    		int caret = this.GetCharIndexFromPosition(p);
    		String t = this.Text;
    		String s = "";
    		int index = 0;
    		StringBuilder sb = new StringBuilder();
    		bool needsFix = false;
    		for (int i = 0; i <= t.Length; i++) {
    			char c = (i == t.Length ? ':' : t[i]);
    			if (Char.IsDigit(c))
    				s += c;
    			else {
    				int max = maxs[index];
    				int v = int.Parse(s);
    				if (v >= max) {
    					caret = i;
    					needsFix = true;
    					v = max - 1;
    				}
    				sb.Append(v.ToString().PadLeft(s.Length, '0'));
    				if (i < t.Length)
    					sb.Append(c);
    				s = "";
    				index++;
    			}
    		}
    
    		if (needsFix) {
    			isValidating = true;
    			this.Text = sb.ToString();
    			this.BeginInvoke((Action) delegate {
    				this.SelectionStart = caret;
    			});
    			isValidating = false;
    		}
    	}
    
    	protected override void OnKeyDown(KeyEventArgs e) {
    		if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) {
    			var t = this.Text;
    			int x = this.SelectionStart;
    			int xOld = x;
    			while (x > 0) {
    				char c = t[x-1];
    				if (!Char.IsDigit(c))
    					break;
    				x--;
    			}
    			String s = "";
    			for (int i = x; i < t.Length; i++) {
    				char c = t[i];
    				if (Char.IsDigit(c))
    					s += c;
    				else
    					break;
    			}
    			int index = 0;
    			for (int i = 0; i < x; i++) {
    				char c = t[i];
    				if (!Char.IsDigit(c))
    					index++;
    			}
    			int v = int.Parse(s) + (e.KeyCode == Keys.Down ? -1 : 1);
    			int max = maxs[index];
    			if (v < 0)
    				v = max - 1;
    			else if (v == max)
    				v = 0;
    
    			String vt = v.ToString().PadLeft(s.Length, '0');
    			String t2 = t.Substring(0, x) + vt + t.Substring(x + vt.Length);
    			isValidating = true;
    			this.Text = t2;
    			isValidating = false;
    			BeginInvoke((Action) delegate {
    				this.SelectionStart = xOld;
    			});
    		}
    		else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) {
    			int x = this.SelectionStart;
    			int l = this.SelectionLength;
    			var t = this.Text;
    			Point p = Point.Empty;
    			GetCaretPos(out p);
    			int caret = 0;
    			String s = "";
    			if (l > 0) {
    				caret = this.GetCharIndexFromPosition(p);
    				for (int i = 0; i < t.Length; i++) {
    					char c = t[i];
    					if (i >= x && i < x + l && Char.IsDigit(c))
    						c = '0';
    
    					s += c;
    				}
    			}
    			else if (e.KeyCode == Keys.Delete) {
    				caret = SelectionStart;
    				if (caret == t.Length)
    					return;
    				if (caret < t.Length && !Char.IsDigit(t[caret]))
    					caret++;
    				s = t.Substring(0, caret) + '0' + t.Substring(caret + 1);
    				caret = caret + 1;
    			}
    			else if (e.KeyCode == Keys.Back) {
    				caret = SelectionStart;
    				if (caret == 0)
    					return;
    				if (!Char.IsDigit(t[caret - 1]))
    					caret--;
    				s = t.Substring(0, caret - 1) + '0' + t.Substring(caret);
    				caret = caret - 1;
    			}
    
    			BeginInvoke((Action) delegate {
    				this.Text = s;
    				this.SelectionStart = caret;
    			});
    
    			e.Handled = true;
    			e.SuppressKeyPress = true;
    		}
    
    		isValidating = true;
    		base.OnKeyDown(e);
    		isValidating = false;
    	}
    
    	public DateTime Value {
    		get {
    			return DateTime.ParseExact(this.Text, TimeFormat, CultureInfo.CurrentCulture, DateTimeStyles.None);
    		}
    		set {
    			this.Text = value.ToString(TimeFormat);
    		}
    	}
    }
