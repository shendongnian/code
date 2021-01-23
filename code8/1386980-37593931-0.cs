    // create template matching algorithm's instance
    // use zero similarity to make sure algorithm will provide anything
    ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0);
    // compare two images
    TemplateMatch[] matchings = tm.ProcessImage(image1, image2);
    // check similarity level
    if (matchings[0].Similarity > 0.95f)
    {
        // do something with quite similar images
    }
