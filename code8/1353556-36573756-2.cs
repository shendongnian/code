    public Image clay, sand, loam, silt, siltyClay, siltyLoam, loamySand, sandyLoam, siltyClayLoam;
    [System.Serializable]
    public class ImageColorPairs 
    {
        public Image[] images; /* associate Images */
        public Color targetColor; /* ..with a target color */
    }
    /* Make up array of Pairs here */
    private ImageColorPairs[] pairs = new ImageColorPairs[] { 
                new ImageColorPairs() { images = { sand }, targetColor = Color.green } }, 
                new ImageColorPairs() { images = { clay, loam, silt, siltyClay, siltyLoam, loamySand, sandyLoam, siltyClayLoam }, targetColor = Color.white } };
    
    public void ImageColor(){
            /* Now setting the colors is easy! :) */
            foreach(var pair in pairs)
            {
               foreach(var image in pair.images)
               {
                   image.color = pair.targetColor;
               }
            }
    }
