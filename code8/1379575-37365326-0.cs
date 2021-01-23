    public class find
    {
      string[] stores = {"Third Street Promenade, 1220 3rd St, Santa Monica, CA 90401", "802 N San Vicente Blvd, West Hollywood, CA 90069", "7726 Melrose Ave, Los Angeles, CA 90046", "1060 Westwood Blvd, Los Angeles, CA 90024", "6922 Hollywood Blvd, Los Angeles, CA 90028","363 E 2nd St, Los Angeles, CA 90012","747 Warehouse St, Los Angeles, CA 90021","2654 Main St, Santa Monica, CA 90405"};
      string value_to_find = "walter,6922 Hollywood Blvd. Los Angeles, CA 90028";
      foreach(var found in stores.Where(x => x.Equals(value_to_find)))
      {
        Console.Write("Found");
      }
    }
