    interface IGameInput
    {
        float GetXMovement();
        float GetYMovement();
    }
    class KeyboardInput : IGameInput
    {
        public float GetXMovement()
        {
            var state = Keyboard.GetState();
            var leftDown = state.IsKeyDown(Keys.A);
            var rightDown = state.IsKeyDown(Keys.D);
            float finalValue = 0;
            if (leftDown)
                 finalValue -= 1;
            if (rightDown )
                 finalValue += 1;
            return finalValue;
        }
        public float GetYMovement()
        {
            // Same as X, just check for W and S instead.
        }
    }
    class ControllerInput : IGameInput
    {
        public float GetXMovement()
        {
            var state = Gamepad.GetState(0); // or whatever the syntax is, I forgot.
            var xMovement = state.LeftThumb.X;
            return xMovement;
        }
        public float GetYMovement()
        {
            var state = Gamepad.GetState(0); // same as above
            var yMovement = state.LeftThumb.Y;
            return yMovement;
        }
    }
    // other class
    var x = this.input.GetXMovement() * this.MovementSpeed;
    var y = this.input.GetYMovement() * this.MovementSpeed;
    this.Position = this.Position + new Vector2(x, y);
