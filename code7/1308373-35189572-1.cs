    public class TransformViewer : UserControl {
        private readonly MatrixTransform transform = new MatrixTransform();
        private Point pressedMouse;
        protected override void OnMouseDown(MouseButtonEventArgs e) {
            pressedMouse = transform.Inverse.Transform( e.GetPosition( this ) );
        }
        protected override void OnMouseMove(MouseEventArgs e) {
            if(e.MiddleButton == MouseButtonState.Pressed) {
                Point mouse = transform.Inverse.Transform( e.GetPosition( this ) );
                Vector delta = Point.Subtract( mouse, pressedMouse ); // delta from old mouse to current mouse
                var translate = new TranslateTransform( delta.X, delta.Y );
                transform.Matrix = translate.Value * transform.Matrix;
                ((UIElement) Content).RenderTransform = transform;
                e.Handled = true;
            }
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e) {
                float scale = 1.1f;
                if(e.Delta < 0) scale = 1f / scale;
                Point mouse = e.GetPosition( this );
                Matrix matrix = transform.Matrix;
                matrix.ScaleAt( scale, scale, mouse.X, mouse.Y );
                transform.Matrix = matrix;
                ((UIElement) Content).RenderTransform = transform;
                e.Handled = true;
        }
    }
