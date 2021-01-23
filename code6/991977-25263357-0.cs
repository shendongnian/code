    IPropagatorBlock<InputImage, OutputImage> CreateProcessingBlock()
    {
        InputImage previousImage = null;
    
        return new TransformBlock<InputImage, OutputImage>(
            inputImage =>
            {
                var result = Process(inputImage, previousImage);
                previousImage = inputImage;
                return result;
            })
    }
