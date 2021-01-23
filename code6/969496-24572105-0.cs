    public class ProdImg
    {
        public Product p;
        public FileInfo imgFi;
        public ProdImg(Product _p)
        {
            p = _p;
            imgFi = new FileInfo("C:/" + p.id.ToString() + ".jpg");
        }
        public FileInfo ImgFi
        {
            get { return imgFi ; }
            set {imgFi = value; }
         }
    }
    <Image Source="{Binding ImgFi.FullName}"  />
