            string file = @"New1.jpg";
            double x = 24524.5555598;
            double y = 234123.4123423;
            var img = System.Drawing.Image.FromFile(file);
            // note how to force Activator.CreateInstance to call internal constructor, 
            // it's important to call this overload
            var newProp1 = (PropertyItem) Activator.CreateInstance(typeof(PropertyItem), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[0], CultureInfo.InvariantCulture);
            newProp1.Id = 0x5111;
            newProp1.Type = 1;
            newProp1.Value = BitConverter.GetBytes(x);
            newProp1.Len = newProp1.Value.Length;
            var newProp2 = (PropertyItem)Activator.CreateInstance(typeof(PropertyItem), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[0], CultureInfo.InvariantCulture);
            newProp2.Id = 0x5112;
            newProp2.Type = 1;
            newProp2.Value = BitConverter.GetBytes(y);
            newProp2.Len = newProp1.Value.Length;
            img.SetPropertyItem(newProp1);
            img.SetPropertyItem(newProp2);
            img.Save("New1.jpg", ImageFormat.Jpeg);
