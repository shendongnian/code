    public class AutoClass
    {
           public ImageCollection Imgcoll { get; set; }
    
           public AutoClass()
           {
                  Imgcoll = new ImageCollection();
           }
           public void SomeMethod(someargs)
           {
                  Imgcoll.addImgCollection(img1);
                  Imgcoll.addImgCollection(img2);
           }
    }
