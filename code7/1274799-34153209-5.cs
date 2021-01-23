    Matrix transform = new Matrix(); // start with identity
    write(shapes, transform);
    
    void write(Shape shape, Matrix transform)
    {
       if (shape is TallComponents.PDF.Shapes.ContentShape)
       {
          ContentShape contentshape = (ContentShape)shape;
          // calculate the transformation matrix of the user space
          Matrix newTransform = contentshape.Transform.CreateGdiMatrix();
          newTransform.Multiply(transform, MatrixOrder.Append);
    
          if (shape is FreeHandShape)
          {
             write((FreeHandShape)shape, newTransform);
          }
          else if (shape is ImageShape)
          {
             write((ImageShape)shape, newTransform);
          }
          else if (shape is ShapeCollection)
          {
            // recurse
            ShapeCollection shapes = (ShapeCollection)shape;
            foreach (Shape s in shapes)
               write(s, newTransform);
          }
          // ignore other shapes
       }
    }
