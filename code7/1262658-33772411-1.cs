    var baseChoices = Enumerable.Repeat(Colors.Red, 20)
      .Union(Enumerable.Repeat(Colors.Blue, 20))
      .Union(Enumerable.Repeat(Colors.Green, 5))...;
    
    var shuffledColors = new SuffledChoices<Color>(baseChoices);
    
    ...
    if (e.Button == MouseButtons.Left){
       Form.GetTile(x, y).FrontColour = shuffledColors.PickNext();
    }
