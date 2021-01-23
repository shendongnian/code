    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Utilities;
    using System.Drawing;
    namespace Utilities.Tests
    {
        [TestClass]
        public class ImageUtilitiesTests
        {
            [TestMethod]
            public void GetPngDimensionsTest()
            {
                string url = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";
                Uri uri = new Uri(url);
                var actual = ImageUtilities.GetWebDimensions(uri);
                Assert.AreEqual(new Size(272, 92), actual);
            }
            [TestMethod]
            public void GetJpgDimensionsTest()
            {
                string url = "https://upload.wikimedia.org/wikipedia/commons/e/e0/JPEG_example_JPG_RIP_050.jpg";
                Uri uri = new Uri(url);
                var actual = ImageUtilities.GetWebDimensions(uri);
                Assert.AreEqual(new Size(313, 234), actual);
            }
            [TestMethod]
            public void GetGifDimensionsTest()
            {
                string url = "https://upload.wikimedia.org/wikipedia/commons/a/a0/Sunflower_as_gif_websafe.gif";
                Uri uri = new Uri(url);
                var actual = ImageUtilities.GetWebDimensions(uri);
                Assert.AreEqual(new Size(250, 297), actual);
            }
        }
    }
