            List<Label> allNumberLabels = new List<Label>();
            foreach (Label t in this.Controls.OfType<Label>())
            {                
                if (t.Name.Length > 11)
                {
                    if (t.Name.Substring(5, 6).Equals("Number"))
                    {
                        allNumberLabels.Add(t);
                    }
                }
            }
