    // This is a good
    Basket<Grocery> basket = new Basket<Grocery>();
    var count = basket.Count(); // returns 0
    // This smells bad!
    Basket<Grocery> basket = null
    var count = basket?.Count ?? 0;
