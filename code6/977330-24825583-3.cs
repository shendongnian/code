        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            int boxSize = 20;
            Pen pen = new Pen(new SolidColorBrush(Colors.Black), 1);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rect targetRect = new Rect(i * boxSize, j * boxSize, boxSize, boxSize);
                    if (j % 2 == 0)
                    {
                        Rect elementRect = new Rect(0, 0, boxSize, boxSize);
                        double blurRadius = 5;
                        drawingContext.RenderBlurred(boxSize, boxSize, targetRect, blurRadius, dc => dc.DrawRectangle(new SolidColorBrush(Colors.Transparent), pen, elementRect));
                    }
                    else
                    {
                        drawingContext.DrawRectangle(new SolidColorBrush(Colors.Transparent), pen, targetRect);
                    }
                }
            }
        }
