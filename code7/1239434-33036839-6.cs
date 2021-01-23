            // string installerFileText = File.ReadAllText(installerFileName);
            string installerFileText = @"
            Rows
            ...
            product.people
            product.people_good
            product.people_bad
            product.boy
            ...
            Rows";
            string[] lines = installerFileText.Split(new string[] { "product." }, StringSplitOptions.None);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
                sb.Append(((i > 0 && i < lines.Length) ? "#product." : "") + lines[i]);
            // File.WriteAllText(installerFileName, sb.ToString());
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
