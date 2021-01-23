    Dictionary<string, double> Chemicals = new Dictionary<string, double>() { { "H", 1.00794 }, { "He", 4.002602 }, { "Li", 6.941 }, { "Be", 9.012182 } };
            List<string> Properties = new List<string>();
            Regex reg = new Regex("[A-Z]{1}[a-z0-9]*");
            Properties = reg.Matches(txtInput.Text).Cast<Match>().Select(m => m.Value).ToList();
            double Total = 0;
            foreach (var Property in Properties)
            {
                var result = Regex.Match(Property, @"\d+$").Value;
                int resultAsInt;
                int.TryParse(result, out resultAsInt);
                if (resultAsInt > 0)
                {
                    Total += Chemicals[Property.Substring(0, Property.Length - result.Length)] * resultAsInt;
                }
                else
                {
                    Total += Chemicals[Property];
                }
            }
            lblOutput.Text = "Total: " + Total.ToString();
