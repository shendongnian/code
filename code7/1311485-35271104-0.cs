    Dictionary<string, double> chems = new Dictionary<string, double>() { { "H", 1.00794 }, { "He", 4.002602 }, { "Li", 6.941 }, { "Be", 9.012182 } };
            List<string> props = new List<string>();
            Regex reg = new Regex("[A-Z]{1}[a-z]*");
            props = reg.Matches(txtInput.Text).Cast<Match>().Select(m => m.Value).ToList();
            double sum = 0;
            foreach (var item in props)
            {
                sum += chems[item];
            }
            lblOutput.Text = sum.ToString();
