            if (Clipboard.ContainsText())
            {
                string str = Clipboard.GetText();
                string[] values = str.Split("\t".ToCharArray());
                // ... do something with "values" ...
                xxx.aaa = values[0];
                xxx.bbb = values[1];
                xxx.ccc = values[2];
                // etc...
            }
            else
            {
                MessageBox.Show("No Text in the Clipboard!");
            }
