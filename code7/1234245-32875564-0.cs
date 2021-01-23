            var sb = new StringBuilder();
            int int1 = 50000;
            double double1 = 5800.0;
            sb.AppendFormat("{0,8};{1,8};");
            var indentation = "".PadLeft(sb.Length);
            var test = "Test\r\nSome\r\nMultiline\r\nstuff.";
            var testLines = test.Split(new[] { "\r\n" }, StringSplitOptions.None);
            for (int i=0; i<testLines.Length;i++)
            {
                if (i > 0)
                {
                    sb.AppendFormat("{0}{1}", "\r\n", indentation);
                }
                sb.Append(testLines[i]);
            }
            return sb.ToString();
