    public class TempleListDetails
    {
        private string strTempleImage;
        public String TempleImage
        {
            get {return strTempleImage;}
            set
            {
                if (value == null)
                {
                    strTempleImage= "some image path";
                }
            }
        }
    }
