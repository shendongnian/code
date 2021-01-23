	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Diagnostics;
	public class MultiColorCheckbox : CheckBox
	{
		public MultiColorCheckbox() : base()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);
			this.AutoSize = false;
			this.Width = 50;
		}
		protected override void OnPaint(PaintEventArgs pevent)
		{
			//Draw background
			using (SolidBrush b = new SolidBrush(this.BackColor)) {
				pevent.Graphics.FillRectangle(b, this.ClientRectangle);
			}
			//Draw the checkbox
			ControlPaint.DrawCheckBox(pevent.Graphics, new Rectangle(1, 1, 16, 16), this.Checked ? ButtonState.Checked : ButtonState.Normal);
			//Measure the base string
			Font f = this.Font;
			SizeF s1 = pevent.Graphics.MeasureString("Max Parameters on set ", f);
			Rectangle r1 = new Rectangle(18, 1, s1.Width, this.ClientRectangle.Height - 2);
			//Create string format
			using (StringFormat sf = new StringFormat()) {
				sf.LineAlignment = StringAlignment.Center;
				sf.FormatFlags = StringFormatFlags.NoWrap;
				sf.Trimming = StringTrimming.None;
				//Draw base string
				pevent.Graphics.DrawString("Max Parameters on set ", f, Brushes.Black, r1, sf);
				//Draw secondary string, based on check state
				if (this.Checked) {
					SizeF s2 = pevent.Graphics.MeasureString("ON", f);
					Rectangle r2 = new Rectangle(r1.Right, 1, s2.Width, this.ClientRectangle.Height - 2);
					pevent.Graphics.DrawString("ON", f, Brushes.Green, r2, sf);
				} else {
					SizeF s2 = pevent.Graphics.MeasureString("OFF", f);
					Rectangle r2 = new Rectangle(r1.Right, 1, s2.Width, this.ClientRectangle.Height - 2);
					pevent.Graphics.DrawString("OFF", f, Brushes.Red, r2, sf);
				}
			}
		}
	}
