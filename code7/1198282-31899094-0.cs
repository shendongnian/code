        [TestMethod]
        public void PutExpectationOnDrawText()
        {
            var wasExcute = false;
            System.Windows.Forms.Fakes.ShimTextRenderer
                          .DrawTextIDeviceContextStringFontRectangleColorTextFormatFlags =
                (context, txt, font, pt, forecolor, flags) =>
                {
                    //the asserts on the orguments...
                    //for example:
                    Assert.IsNotNull(context);
                    Assert.AreNotEqual(String.Empty, txt);
                    //...
                    wasExcute = true;
                };
            //execute the method which is use DrawText
            Assert.IsTrue(wasExcute);//verify that the method was execute....
        }
