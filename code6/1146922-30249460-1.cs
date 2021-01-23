    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class RichTextBoxEx : RichTextBox {
        public string Cue {
            get { return cue; }
            set {
                showCue(false);
                cue = value;
                if (this.Focused) showCue(true);
            }
        }
        private string cue;
        protected override void OnEnter(EventArgs e) {
            showCue(false);
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e) {
            showCue(true);
            base.OnLeave(e);
        }
        protected override void OnVisibleChanged(EventArgs e) {
            if (!this.Focused) showCue(true);
            base.OnVisibleChanged(e);
        }
        private void showCue(bool visible) {
            if (this.DesignMode) visible = false;
            if (visible) {                          
                if (this.Text.Length == 0) {
                    this.Text = cue;
                    this.SelectAll();
                    this.SelectionColor = Color.FromArgb(87, 87, 87);
                }
            }
            else {
                if (this.Text == cue) {
                    this.Text = "";
                    this.SelectionColor = this.ForeColor;
                }
            }
        }
    }
