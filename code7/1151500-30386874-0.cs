         namespace ProductDetail.App_Code
         {
             public class ProductDetail
             {
                 public int ID { get; set; }
                 public string Title { get; set; }
                 public string Writer { get; set; }
                 public int Publish { get; set; }
                 public int Publisher_ID { get; set; }
                 public int Category_ID { get; set; }
                 public int Status_ID { get; set; }
                 public string Book_Image_Url { get; set; }
                 public int Jumlah { get; set; }
                 public string Deskripsi { get; set; }
             }
    
             public class ProductDetailAccess
             {
                 public static List<ProductDetail> GetAllProduct(int ID)
                 {
                     List<ProductDetail> ProductList= new List<ProductDetail>();
        
                     string cs = ConfigurationManager.ConnectionStrings["cs_productSample"].ConnectionString;
                     using (SqlConnection con = new SqlConnection(cs))
                     {
                         SqlCommand cmd = new SqlCommand("Select * from T_Product where ID = @ID", con);
                         SqlParameter param = new SqlParameter("@ID", ID);
                         cmd.Parameters.Add(param);
                         con.Open();
                         SqlDataReader rdr = cmd.ExecuteReader();
        
                         while (rdr.Read())
                         {
                             ProductDetail ProductDetail = new ProductDetail();
                             ProductDetail.ID = Convert.ToInt32(rdr["ID"]);
                             ProductDetail.Title = rdr["Title"].ToString();
                             ProductDetail.Writer = rdr["Writer"].ToString();
                             ProductDetail.Publish = Convert.ToInt32(rdr["Publish"]);
                             ProductDetail.Publisher_ID = Convert.ToInt32(rdr["ID_Penerbit"]);
                             ProductDetail.Category_ID = Convert.ToInt32(rdr["Category_ID"]);
                             ProductDetail.Status_ID = Convert.ToInt32(rdr["Status_ID"]);
                             ProductDetail.Book_Image_Url = rdr["Book_Image_Url"].ToString();
                             ProductDetail.Jumlah = Convert.ToInt32(rdr["Jumlah"]);
                             ProductDetail.Deskripsi = rdr["Deskripsi"].ToString();
        
                             ProductList.Add(ProductDetail);
                         }
                     }
                     return ProductList;
                 }
             }
         }
