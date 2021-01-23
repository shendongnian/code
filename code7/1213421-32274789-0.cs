            int i = 0;
            var theSplotStr = text.Split('\n');
            foreach (var item in theSplotStr)
            {
                System.Console.WriteLine(item);
                string revisedString = item.Replace("''", "'" + ++i + "'");
                strBuilder.Append(revisedString+"\n");
                
            }
            File.WriteAllText("C:\\Users\\person\\Desktop\\new.sql", strBuilder.ToString());
