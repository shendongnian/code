    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip | ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class ToolStripRadioItem : ToolStripMenuItem {
        public int Group { get; set; }
    
        protected override void OnClick(EventArgs e) {
            if (!this.DesignMode) {
                this.Checked = true;
                var parent = this.Owner as ToolStripDropDownMenu;
                if (parent != null) {
                    foreach (var item in parent.Items) {
                        var sibling = item as ToolStripRadioItem;
                        if (sibling != null && sibling != this and sibling.Group == this.Group) sibling.Checked = false;
                    }
                }
            }
            base.OnClick(e);
        }
    }
 
