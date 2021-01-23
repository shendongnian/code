        // resize a button
        private class AnimateButton : ICommandExecutor
        {
            // keep track of instances of this class
            static ConcurrentDictionary<Button, AnimateButton> dict = new ConcurrentDictionary<Button, AnimateButton>();
            // Update or create an animation for a button
            static public void Animate(Button sender, Direction direction)
            {
                AnimateButton animate;
                // find it...
                if (dict.TryGetValue(sender, out animate))
                {
                    animate.SetDirection(direction);
                }
                else
                {
                    // create a new one
                    animate = new AnimateButton(sender);
                    animate.SetDirection(direction);
                    if (dict.TryAdd(sender, animate))
                    {
                        Animations.List.Add(animate);
                    } 
                    else
                    {
                        Trace.WriteLine("button not added ?!?");
                    }
                }
            }
            int initialWidth = 75;
            int endWidth = 130;
            public enum Direction
            {
                None,
                Shrink,
                Grow
            }
            Direction direction = Direction.None;
            readonly Button button;
            private AnimateButton(Button button)
            {
                this.button = button;
            }
            public void SetDirection(Direction direction )
            {
                this.direction = direction;
            }
            // this gets called by the progress event
            public void Execute()
            {
                switch(direction)
                {
                    case Direction.Grow:
                        if (button.Width < endWidth)
                        {
                            button.Width++;
                        }
                        else
                        {
                            direction =  Direction.None;
                        }
                        break;
                    case Direction.Shrink:
                        if (button.Width > initialWidth)
                        {
                            button.Width--;
                        }
                        else
                        {
                            direction = Direction.None;
                        }
                        break;
                }
            }
        }
