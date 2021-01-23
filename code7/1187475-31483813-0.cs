            var dict = new Dictionary<int, string>();
            dict.Add(0, "QATestFileGenTools.checkFront1.bmp");
            dict.Add(1,"QATestFileGenTools.checkFront2.bmp");
            dict.Add(2, "QATestFileGenTools.checkFront2.bmp");
            Random rnd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int randomInt = rnd.Next(0, 2);
            string resourceName = dict[randomInt];
            System.IO.Stream file file = thisExe.GetManifestResourceStream(resourceName);
