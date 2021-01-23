    public class ProductDa
    {
        //CRUD operations using Dapper
        public List<Product> GetAllElements();
        //query database using Dapper to get all the elements where Value == value
        public List<Product> GetAllElementsWithValue(int value);
    }
