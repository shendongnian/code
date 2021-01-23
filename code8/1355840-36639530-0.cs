    using System.Drawing;
    using System.Resources;
    ...
    ResourceManager resManager = new ResourceManager("YourRootNamespace.YourResourceFileName", GetType().Assembly);
    Image myImage = (Image)(resManager.GetObject("ImageNameInResourceFile"));
    picBox1.Image = myImage;
