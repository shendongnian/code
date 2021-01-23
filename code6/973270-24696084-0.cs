    public class Item
    {
      public int ItemId { get; set; }
      public string Name { get; set; }
      public List<Tag> Tags { get; set; }
      [NotMapped]
      public string TagIds
      {
        set
        {
          if (Tags == null) return null;
          return string.Join(",", Tags.Select(t => t.TagId.ToString).ToArray());
        }
        //get
        //{
           // If you need you can implement this with string.Split and update the Tags
        //}
      }
    }
