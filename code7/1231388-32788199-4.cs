    bool IsComplete = false;
    while (!(IsComplete = ImageProcessor.frameQueue.isCompleted())) 
                {             
                    using (Bitmap image = ImageProcessor.frameQueue.Dequeue())
                    {
                        Console.WriteLine("Height: " + image.Height);
                        Console.WriteLine("Width: " + image.Width);                    
                    }                
                }
