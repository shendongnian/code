    public class ProfileImages {
        public static string ImagePath {
            get {
                return "~/Assets/Images/user_images/avatars/123@123.com.jpg";
            }
        }
    }
    ...
    <img src="@Url.Content(NsProfileImages.ProfileImages.ImagePath)" 
         class="dker" alt="..." />
