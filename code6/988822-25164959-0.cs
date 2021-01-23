    event EventHandler IDrawingObject.OnDraw
        {
            add
            {
                lock (PreDrawEvent)
                {
                    // Write your custom code here
                    PreDrawEvent += value;
                }
            }
            remove
            {
                lock (PreDrawEvent)
                {
                    PreDrawEvent -= value;
                }
            }
        }
