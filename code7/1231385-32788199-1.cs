            Bitmap image = new Bitmap();
	        image = ImageProcessor.frameQueue.Dequeue())
         
                Console.WriteLine("Height: " + image.Height);
                Console.WriteLine("Width: " + image.Width);                    
            image.Dispose();
