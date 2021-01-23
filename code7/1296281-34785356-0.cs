    class FooRepository {
       private _db;
       public FooRepository(SqlConnection db) {
           _db = db;
       }
       public FooModel GetFooModelById(int id) {
           //...
           var model = new FooModel {
               Value1 = reader["val1"].ToString(),          
               Value2 = reader["val2"].ToString()          
           };
           //...
       }
       public List<FooModel> GetFooModelCollection() {
           //...
       }
    }
