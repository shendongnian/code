    [TestMethod]
    [TestCategory("ImageHelper")]
    [TestCategory("ResizeImage")]
    public void ResizeImage_LandscapeTooLarge_SmallerLandscape()
    {
        Image testImageLandscape = Resources.TestImageLandscapeDesert;
        const int HEIGHT = 300;
        const int WIDTH = 300;
        const int EXPECTED_WIDTH = WIDTH;
        const int EXPECTED_HEIGHT = (int)(EXPECTED_WIDTH / (1024m / 768m));
        const PixelFormat EXPECTED_FORMAT = PixelFormat.Format48bppRgb;
        bool calledBitMapConstructor = false;
        bool calledGraphicsFromImage = false;
        bool calledGraphicsDrawImage = false;
        using (ShimsContext.Create())
        {
            ShimBitmap.ConstructorInt32Int32PixelFormat = (instance, w, h, f) => {
                calledBitMapConstructor = true;
                Assert.AreEqual(EXPECTED_WIDTH, w);
                Assert.AreEqual(EXPECTED_HEIGHT, h);
                Assert.AreEqual(EXPECTED_FORMAT, f);
                ShimsContext.ExecuteWithoutShims(() => {
                    ConstructorInfo constructor = typeof(Bitmap).GetConstructor(new[] { typeof(int), typeof(int), typeof(PixelFormat) });
                    Assert.IsNotNull(constructor);
                    constructor.Invoke(instance, new object[] { w, h, f });
                });
            };
            ShimGraphics.FromImageImage = i => {
                calledGraphicsFromImage = true;
                Assert.IsNotNull(i);
                return ShimsContext.ExecuteWithoutShims(() => Graphics.FromImage(i));
            };
            ShimGraphics.AllInstances.DrawImageImageInt32Int32Int32Int32 = (instance, i, x, y, w, h) => {
                calledGraphicsDrawImage = true;
                Assert.IsNotNull(i);
                Assert.AreEqual(0, x);
                Assert.AreEqual(0, y);
                Assert.AreEqual(EXPECTED_WIDTH, w);
                Assert.AreEqual(EXPECTED_HEIGHT, h);
                ShimsContext.ExecuteWithoutShims(() => instance.DrawImage(i, x, y, w, h));
            };
            using (Image resizedImage = ImageHelper.ResizeImage(testImageLandscape, HEIGHT, WIDTH))
            {
                Assert.IsNotNull(resizedImage);
                Assert.AreEqual(EXPECTED_WIDTH, resizedImage.Size.Width);
                Assert.AreEqual(EXPECTED_HEIGHT, resizedImage.Size.Height);
                Assert.AreEqual(EXPECTED_FORMAT, resizedImage.PixelFormat);
            }
        }
        Assert.IsTrue(calledBitMapConstructor);
        Assert.IsTrue(calledGraphicsFromImage);
        Assert.IsTrue(calledGraphicsDrawImage);
    }
