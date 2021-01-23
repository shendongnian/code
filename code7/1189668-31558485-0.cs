    public class AutoClass
    {
           public ImageCollection Imgcoll { get; set; }
    
           public void SomeMethod()
           {
                  Imgcoll = new ImageCollection();
                  Imgcoll.addImgCollection(img1);
                  Imgcoll.addImgCollection(img2);
           }
    }
