    public static void GetImages()
            {
                var doc = PresentationDocument.Open(@"D:\Peak Sourcing\Work\ppt_test\xx.pptx", true);
    
                var presentationPart = doc.PresentationPart;
    
                int number_of_slides = presentationPart.GetPartsOfType<SlidePart>().Count(); //get number of slides in .ppt
    
    
    
    
                var slidePart = presentationPart.GetPartsOfType<SlidePart>().ElementAt(5); //look for image inside this slide number + 1
    
                int number_of_images = slidePart.GetPartsOfType<ImagePart>().Count(); //get number of images in current slide
    
                var imagePart = slidePart.GetPartsOfType<ImagePart>().ElementAt(0); //should return first image of selected slide, but it doesn't....it returns an image from some other slide
    
                var stream = imagePart.GetStream();
    
                var img = Image.FromStream(stream);
    
                img.Save(@"D:\Peak Sourcing\Work\ppt_test\test-output.jpg");
    
            }
