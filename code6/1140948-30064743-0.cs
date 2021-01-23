    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    class TransparentTabControl : TabControl {
        private List<Panel> pages = new List<Panel>();
        private Size designSize;
    
        protected override void OnParentChanged(EventArgs e) {
            base.OnParentChanged(e);
            // Move controls
            for (int tab = 0; tab < TabCount && !DesignMode; ++tab) {
                var page = new Panel {
                    Left = this.Left, Top = this.Height,
                    Size = designSize, BackColor = Color.Transparent,
                    Visible = tab == this.SelectedIndex
                };
                for (int ix = TabPages[tab].Controls.Count - 1; ix >= 0; --ix) {
                    TabPages[tab].Controls[ix].Parent = page;
                }
                pages.Add(page);
                this.Parent.Controls.Add(page);
            }
        }
    
        protected override void OnResize(EventArgs e) {
            if (!DesignMode && TabCount > 0) {
                if (designSize == Size.Empty) designSize = this.Size;
                this.Height = GetTabRect(0).Bottom /* + 1 */;
            }
            base.OnResize(e);
        }
    
        protected override void OnSelectedIndexChanged(EventArgs e) {
            base.OnSelectedIndexChanged(e);
            for (int tab = 0; tab < pages.Count; ++tab) {
                pages[tab].Visible = tab == SelectedIndex;
            }
        }
    }
