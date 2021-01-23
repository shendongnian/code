    private Color GetRandomColor()
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
        return colorArray[r.Next(colorArray.Length-1)];
    }
