    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
        public class ImageService : IImageService
        {
            public bool CheckQualityOfImage(CheckQuality objCheckQuality)
            {
                if (objCheckQuality != null)
                {
                    if (objCheckQuality.ImageData.Length > 0 && ! String.IsNullOrEmpty(objCheckQuality.ImageFileName))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }
