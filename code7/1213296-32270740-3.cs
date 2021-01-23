    private Color[] GetRandomColor()
    {
        Random r = new Random((int)DateTime.Now.Ticks);
        var colorArray = new Color[] 
            { 
               Color.Red, 
               Color.Blue, 
               Color.Yellow, 
               Color.Lime, 
               Color.Purple 
             };
         for (int i = 0; i < colorArray.Length; i++)
         {
             var j = r.Next(colorArray.Length - 1);
             var k = r.Next(colorArray.Length - 1);
             var temp = colorArray[j];
             colorArray[j] = colorArray[k];
             colorArray[k] = temp;
         }
         return colorArray.Take(4).ToArray()
    }
   
