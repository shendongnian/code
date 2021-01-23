      private XmlDocument GetXML() {
        myListView.InvokeSynchronized(() => {
          foreach(ListViewItem lvi in myListView.Items) {
            // Do Stuff
          }
        });
      }
    
      ...
    
      public static class ControlAsyncExtensions {
        public static void InvokeSynchronized(this Control control, Action action) {
          if (Object.ReferenceEquals(null, action))
            throw new ArgumentNullException("action");
    
          if (Object.ReferenceEquals(null, control))
            action();
          else if (control.InvokeRequired)
            control.Invoke(action);
          else
            action();
        }
      }
