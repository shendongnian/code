    public class TreeViewEx : TreeView {
      public event TreeViewEventHandler NodeMouseLeave;
      private System.Windows.Forms.Timer timer;
      private TreeNode mouseNode = null;
      public TreeViewEx() {
        if (System.ComponentModel.LicenseManager.UsageMode == LicenseUsageMode.Runtime) {
          timer = new System.Windows.Forms.Timer();
          timer.Tick += timer_Tick;
          timer.Enabled = true;
        }
      }
      protected void OnNoseMouseLeave(TreeViewEventArgs e) {
        if (this.NodeMouseLeave != null) {
          this.NodeMouseLeave(this, e);
        }
      }
      void timer_Tick(object sender, EventArgs e) {
        if (this.ClientRectangle.Contains(this.PointToClient(MousePosition))) {
          TreeNode testNode = this.GetNodeAt(this.PointToClient(MousePosition));
          if (testNode == null) {
            if (mouseNode != null) {
              OnNoseMouseLeave(new TreeViewEventArgs(mouseNode));
              mouseNode = null;
            }
          } else {
            if (mouseNode != null && !testNode.Equals(mouseNode)) {
              OnNoseMouseLeave(new TreeViewEventArgs(mouseNode));
            }
            mouseNode = testNode;
          }
        } else {
          if (mouseNode != null) {
            OnNoseMouseLeave(new TreeViewEventArgs(mouseNode));
            mouseNode = null;
          }
        }
      }
    }
