            var Linha = Regex.Replace(text, @"\/\**?\*\/", " "); // Removes /* */ comments
            Linha = Regex.Replace(Linha, @"(^|\s+)--.*", ""); // Removes -- comments 
            var Commands = Linha.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
               .Where(line => !string.IsNullOrWhiteSpace(line))
               .ToArray();
