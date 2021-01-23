        private void MyCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs)
        {                        
            if (MyTransform_type == TRANSFORM_TYPE.ROTATE)
            {
               _shape = e.OriginalSource as Shape;
               //creating new RotateTransform
               rt=new RotateTransform();
               if (_shape != null)
               {
                  _shape = (Shape)e.OriginalSource;
               }
            }
        }
