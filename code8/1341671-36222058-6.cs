       string xml = "<a><b a=\"a\"><c><d>d</d></c></b><b a=\"a\"><c><d>d</d></c></b><e b=\"b\" a=\"a\"><f>f</f></e></a>";
       XElement xdoc = XElement.Parse(xml);
       Format(xdoc, 0);
       Console.WriteLine(xdoc.ToString(SaveOptions.DisableFormatting));
        static void Format(XElement x, int level)
        {
            foreach (var x1 in x.Elements())
                Format(x1, level + 1);
            if (level > 0)
            {
                x.AddBeforeSelf(Environment.NewLine + new string(' ', 2 * level));
                if (x.Parent.LastNode == x)
                {
                    string ending = Environment.NewLine;
                    if (level > 1)
                        ending += new string(' ', 2 * (level - 1));
                    x.AddAfterSelf(ending);
                }
            }
        }
