    StringBuilder Builder = new StringBuilder();
            string Spacing = Environment.NewLine;
            string newline = "";
            foreach (string s in ArrSkills)
            {
                newline = string.Format("{0}{1}", Spacing, s);
                foreach (var Item in newline)
                {
                    Builder.Append(Item);
                }
            }
            GetSkills = Builder.ToString();
