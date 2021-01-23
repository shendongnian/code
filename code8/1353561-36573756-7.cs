    [System.Serializable]
    public class ImageTuple
    {
        public Image image;
        public Color targetColor;
        public ImageTuple(Image img, Color col)
        {
            image = img;
            targetColor = col;
        }
    }
    private ImageTuple[] imageTuples; 
    public void InitializeTuplesOnce()
    {
        imageTuples = new ImageTuple[]
        {
            new ImageTuple(clay, Color.green),
            new ImageTuple(sand, Color.white),
            //.. the rest
        };
    }
    public void ImageColor()
    {
        foreach (var pair in imageTuples)
        {
            pair.image.color = pair.targetColor;
        }
    }
 
