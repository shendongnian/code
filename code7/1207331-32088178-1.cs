            ...
            xmlnode = xmldoc.GetElementsByTagName("SSIS:Parameters");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
               var val = xmlnode[i].FirstChild.Attributes["SSIS:Name"].Value;
               Console.WriteLine(val);
            }
            Console.ReadLine();
            ...
