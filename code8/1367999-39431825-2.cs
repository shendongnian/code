    HandleCreated += (s, e) => {
       var maybeForm = FindForm();
       if (maybeForm == null)
          return; // or throw since you should have a form by now
       var form = maybeForm;
       MouseEventHandler mouseScrollDelegate = (s, e) => MouseScroll(e.Delta);
       foreach (var control in form.Controls.Cast<Control>())
          control.MouseWheel += mouseScrollDelegate;
    };
    ...
    void MouseScroll(int pDelta) {
       var screenMouse = Cursor.Position;
       var clientMouse = PointToClient(screenMouse);
       if (!ClientRectangle.Contains(clientMouse))
          return;
         
       // do something
    }
