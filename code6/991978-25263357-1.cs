    class Processor
    {
        InputImage previousImage;
    
        public OutputImage Process(InputImage inputImage)
        {
            var result = Process(inputImage, previousImage);
            previousImage = inputImage;
            return result;
        }
    }
    
    …
    
    new TransformBlock<InputImage, OutputImage>(new Processor().Process)
