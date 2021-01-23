    public class BaseModel
    {
        public int Id { get; set; }
    }
    public static bool GetDuplicates<T>(List<T> items) where T : BaseModel
    {           
        foreach (var item in items)
        {
            var myId = item.Id;
            //Do you logic here
        }
        return true;
    }
