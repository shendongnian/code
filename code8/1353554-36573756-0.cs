    public Image clay, sand, loam, silt, siltyClay, siltyLoam, loamySand, sandyLoam, siltyClayLoam;
    [System.Serializable]
    public class ImageColorPairs 
    {
        public Image[] Images; /* associate Images */
        public Color TargetColor; /* ..with a target color */
    }
    /* Make up array of Pairs here */
    private ImageColorPairs[] pairs = new ImageColorPairs[] { 
                new ImageColorPairs() { Images = { sand }, TargetColor = Color.green } }, 
                new ImageColorPairs() { Images = { clay, loam, silt, siltyClay, siltyLoam, loamySand, sandyLoam, siltyClayLoam }, TargetColor = Color.white } };
    
    public void imageColor(){
            /* Now setting the colors is easy! :) */
            foreach(var pair in pairs)
            {
               foreach(var image in pair.Images)
               {
                   image.color = pair.TargetColor;
               }
            }
    }
