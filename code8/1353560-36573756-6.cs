    public Image clay, sand, loam, silt, siltyClay, siltyLoam, loamySand, sandyLoam, siltyClayLoam;
    [System.Serializable]
    public class ImageColorPairs
    {
        public Image[] images {get;set; } /* associate Images */
        public Color targetColor { get; set; } /* ..with a target color */
    }
    private ImageColorPairs[] pairs; //Declare here but initialize later. Can't initialize these objects (error: referencing non-static field..)
    public void InitializePairsOnce()
    {
        /* Make up array of Pairs here */
        pairs = new ImageColorPairs[] {
            new ImageColorPairs() { images = new Image[] { sand }, targetColor = Color.green } ,
            new ImageColorPairs() { images = new Image[] { clay, loam, silt, siltyClay, siltyLoam, loamySand, sandyLoam, siltyClayLoam }, targetColor = Color.white }
     };
    }
    
    public void ImageColor()
    {
        /* Now setting the colors is easy! :) */
        foreach (var pair in pairs)
        {
            foreach (var image in pair.images)
            {
                image.color = pair.targetColor;
            }
        }
    }
