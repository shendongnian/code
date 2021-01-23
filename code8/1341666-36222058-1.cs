            string xml = "<a><b>b</b><c>c</c></a>";
            XElement xdoc = XElement.Parse(xml);
            var b = xdoc.Element("b");
            b.AddBeforeSelf("  "); 
            b.AddAfterSelf(new XText("   ")); //the same as above
            Console.WriteLine(xdoc.ToString(SaveOptions.DisableFormatting));
