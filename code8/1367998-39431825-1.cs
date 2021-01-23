    HandleCreated += (s, e) => {
       var maybeForm = FindForm();
       if (maybeForm == null)
          return; // or throw since you should have a form by now
       var form = maybeForm;
       form
       .Controls
       .Cast<Control>()
       .ForEach(control =>
          control.MouseWheel += (s2, e2) => MouseScroll(e2.Delta)
       );
    };
    ...
    void MouseScroll(int pDelta) {
       var screenMouse = Cursor.Position;
       var clientMouse = PointToClient(screenMouse);
       if (!ClientRectangle.Contains(clientMouse))
          return;
         
       // do something
    }
