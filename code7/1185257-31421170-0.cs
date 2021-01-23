    string sentence = "I am good, Is he good";
           
            var words = sentence.Split(new char[]{' ',','}).Distinct(StringComparer.CurrentCultureIgnoreCase);
            var stringBuilder = new StringBuilder();
            foreach(var item in words)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(" ");
            }
            Console.Write(stringBuilder);
            Console.ReadLine();
