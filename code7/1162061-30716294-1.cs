BLL Project
    public class BLL_Some_Class
    {
      private Shipper _shipper = new Shipper();
      
      public Shipper getShipper
         {
           get{ return _shipper; }
          } 
    } 
PL DAL Project
    BLL_Some_Class bll1 = new BLL_Some_Class();
    bll1.getShipper;
