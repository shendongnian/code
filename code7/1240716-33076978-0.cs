    public class PageSize {
      public double Width { get; private set; }
      public double Height { get; private set; }
      public PageSize(double width, double height) {
        Width = width;
        Height = height;
      }
    
      public static PageSize A4 = new PageSize(210, 297);
      public static PageSize Letter = new PageSize(215.9, 279.4);
    
      public static PageSize Small = new PageSize(148, 210);
      public static PageSize Medium = A4;
      public static PageSize Large = new PageSize(297, 420);
    }
