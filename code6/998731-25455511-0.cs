    public class MinifyTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            string bundleResponse = string.Empty;
            foreach (FileInfo file in response.Files)
            {
                //Minify file
            }
            response.Content = bundleResponse ;
        }
    }
