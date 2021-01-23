                string input =
                    "dateTime1 = new DateTime(2015, 5, 24);" +
                    "line2 ( some code)...;" +
                    "line3 ( some code)...;" +
                    "DateTimePicker.Value = dateTime1;";
                string pattern = "(?'line1'[^;]*);(?'line2'[^;]*);(?'line3'[^;]*);(?'line4'[^;]*)";
                Regex expr = new Regex(pattern, RegexOptions.Singleline);
                string output = expr.Replace(input, "${line2};${line3};${line1};");
    ​
