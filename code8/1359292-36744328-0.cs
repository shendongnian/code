    public class User
    	{
    		public int Id { get; set; }
    
    		public string Isim { get; set; }
    
    		public string Soyad { get; set; }
    
    		public class User(){}
    		
    		public User(int id, string isim, string soyad)
    		{
    			Id = id;
    			Isim = isim;
    			Soyad = soyad;
    		}
    	}
	
