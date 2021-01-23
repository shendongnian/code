    public void FindRectangles(Bitmap bitmap, Rectangle searchArea, List<Rectangle> results)
    {
        // Find the first non-transparent pixel within the search area. 
        // Ensure that it is the pixel with the lowest y-value possible
        Point p;
        if (!TryFindFirstNonTransparent(bitmap, searchArea, out p))
        {
            // No non-transparent pixels in this area
            return;
        }
        // Find its rectangle within the area
        Rectangle r = GetRectangle(bitmap, p, searchArea);
        results.Add(r);
        // No need to search above the rectangle we just found
        Rectangle left = new Rectangle(searchArea.Left, r.Top, r.Left - searchArea.Left, searchArea.Bottom - r.Top);
        Rectangle right = new Rectangle(r.Right, r.Top, searchArea.Right - r.Right, searchArea.Bottom - r.Top);
        Rectangle bottom = new Rectangle(r.Left, r.Bottom, r.Width, searchArea.Bottom - r.Bottom);
        FindRectangles(bitmap, left, results);
        FindRectangles(bitmap, right, results);
        FindRectangles(bitmap, bottom, results);
    }
