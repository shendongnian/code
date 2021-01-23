    namespace timbangan
    {
        public static class Koneksi
        {
            public static MySqlConnection konek;
    
            private static string konfigKoneksi = "Server=localhost;Database=timbangan;Uid=root;Pwd=";
    
            public static MySqlConnection GetConnection()
            {
                konek = new MySqlConnection(konfigKoneksi);
                konek.Open();
            }
        }//end of koneksi
    
        public class Isidata
        {
            public int InsertData(string berat_filter, string qty, string nama_barang, string dari, string shift)
            {
                 sql = @"insert into tb_timbang
                 (BERAT_FILTER,QTY,NAMA_BARANG,DARI,SHIFT) 
                 values (@berat_filter,@qty,@nama_barang,@dari,@shift)";
                 try
                 {
                        using(MySqlConnection cnn = Koneksi.GetConnection())
                        using(MySqlCommand cmd = new MySqlCommand(sql, cnn))
                        {
                           cmd.Parameters.Add("@berat_filter", MySqlDbType.VarChar).Value = berat_filter;
                           cmd.Parameters.Add("@qty", MySqlDbType.VarChar).Value = qty;
                           cmd.Parameters.Add("@name_barang", MySqlDbType.VarChar).Value = nama_barang;
                           cmd.Parameters.Add("@dari", MySqlDbType.VarChar).Value = dari;
                           cmd.Parameters.Add("@shift", MySqlDbType.VarChar).Value = shift;
                           return cmd.ExecuteNonQuery();
                    }
        
                    catch (Exception)
                    {
                        MessageBox.Show("error " + ex.Message);
                        return -1;
                    }
                }
            }
         }//end of issdata
    }//end of timbangan
