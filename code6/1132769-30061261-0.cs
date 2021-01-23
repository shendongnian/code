            public void SetObjectSize()
            {
                int objectSize = 0;
                for (int objectsPerRow = 1; objectsPerRow <= objects.Count ; objectsPerRow++)
                {
                    int rows =(int)Math.Ceiling(((double)objects.Count) / objectsPerRow);
                    int horizontalSize = (this.size.Height - (rows * spacing + spacing)) / rows;
                    int verticalSize = (this.size.Width - (objectsPerRow * spacing + spacing)) / objectsPerRow;
                    int newSize = horizontalSize < verticalSize ? horizontalSize : verticalSize ;
                    if (newSize > objectSize)
                    {
                        this.rows = rows;
                        this.objectsPerRow = objectsPerRow ;
                        objectSize = newSize;
                    }
                }
             }
