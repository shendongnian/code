      private Stack<Control> _Stack = new Stack<Control>();
      private void AddControlEventHandler(object sender, EventArgs e)
      {
         this.Controls.Add(addedControl);
         _Stack.Push(addedControl);
      }
      private void RemoveControlEventHandler(object sender, EventArgs e)
      {
         //Get a reference to the last added control from the stack.
         var lastAddedControl = _Stack.Peek();
         //Remove the control
         this.Controls.Remove(lastAddedControl);
         //Remove the reference to the control from the stack
         _Stack.Pop();
      }
