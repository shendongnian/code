       var x=@"<root>
                <value time=""0.345""/>
                <value time=""0.756""/>
                <value time=""0.455""/>
            </root>";
       TextReader tr = new StringReader(x);
       var doc = XDocument.Load(tr);
       var timeSpanResult = TimeSpan.FromSeconds(doc.Descendants("value").Sum(
                    y =>
                    {
                        double value;
                        if (double.TryParse(y.Attribute("time").Value, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                        {
                            return value;
                        }
                        return 0;
                    }));
