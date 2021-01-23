			RadioButton rb1 = new RadioButton { Text = "RB1" };
			RadioButton rb2 = new RadioButton { Text = "RB2" };
			RadioButtonGroup rgb = new RadioButtonGroup(rb1, rb2);
			foreach (RadioButton rb in new [] { rb1, rb2 }) {
				Form f = new Form { Text = rb.Text };
				f.Controls.Add(rb);
				f.Show();
				rb.CheckedChanged += delegate {
					MessageBox.Show(rb.Text + ": " + rb.Checked);
				};
			}
	private class RadioButtonGroup {
		RadioButton[] radioButtons = null;
		public RadioButtonGroup(params RadioButton[] radioButtons) {
			this.radioButtons = radioButtons;
			foreach (var rb in radioButtons) {
				rb.AutoCheck = false;
				rb.Click += rb_Click;
			}
		}
		void rb_Click(object sender, EventArgs e) {
			foreach (RadioButton rb in radioButtons)
				rb.Checked = (rb == sender);
		}
	}
