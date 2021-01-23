    public class DataResponse<T>
    {
    public DataResponse()  
    {
        this.Data = new List<T>();
        IsSuccessful = true;
    }
    
    public bool IsSuccessful { get; set; }
    public string[] ErrorMessages { get; set; }
    public List<T> Data { get; set; }
    }
