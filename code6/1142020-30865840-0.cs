    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    [ProvideProperty("Blink", typeof(Label))]
    public class BlinkProvider : Component, IExtenderProvider {
        public BlinkProvider() {
            timer = new Timer();
            timer.Tick += timer_Tick;
            Interval = 500;
            Enabled = true;
            BlinkingColor = Color.Red;
        }
        public BlinkProvider(IContainer container)
            : this() {
            container.Add(this);
        }
    
        protected override void Dispose(bool disposing) {
            if (disposing) timer.Dispose();
            base.Dispose(disposing);
        }
    
        [DefaultValue(500)]
        public int Interval {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }
    
        [DefaultValue(true)]
        public bool Enabled { get; set; }
    
        [DefaultValue(typeof(Color), "255, 255, 0, 0")]
        public Color BlinkingColor {
            get;
            set;
        }
    
        private void timer_Tick(object sender, EventArgs e) {
            if (this.DesignMode) return;
            tock = !tock;
            foreach (var lbl in labels.Keys) {
                if (labels[lbl].Blink && Enabled && tock) lbl.ForeColor = BlinkingColor;
                else lbl.ForeColor = labels[lbl].ForeColor;
            }
        }
    
        bool IExtenderProvider.CanExtend(object extendee) {
            return extendee is Label;
        }
        public bool GetBlink(Label label) {
            AddLabelIfNecessary(label);
            return labels[label].Blink;
        }
        public void SetBlink(Label label, bool blink) {
            AddLabelIfNecessary(label);
            labels[label].Blink = blink;
        }
        private void AddLabelIfNecessary(Label label) {
            if (!labels.ContainsKey(label)) {
                labels.Add(label, new BlinkInfo { Blink = false, ForeColor = label.ForeColor });
            }
            timer.Enabled = !DesignMode;
        }
    
        private Timer timer;
        private bool tock;
        private class BlinkInfo {
            public Color ForeColor;
            public bool Blink;
        }
        private Dictionary<Label, BlinkInfo> labels = new Dictionary<Label, BlinkInfo>();
    }
