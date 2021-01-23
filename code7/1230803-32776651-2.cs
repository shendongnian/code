        private void chklbproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string installerfilename = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "Installer.txt");
            IEnumerable<string> inilines = File.ReadAllLines(installerfilename).AsEnumerable();
            string selectedItem = chklbproduct.SelectedItem.ToString();
            bool IsChecked = chklbproduct.CheckedItems.Contains(selectedItem);
            if (IsChecked)
                inilines = inilines.Select(line => line == string.Format("#product={0}", selectedItem) 
                                                   ? line.Replace(line, string.Format("#product={0}", selectedItem), string.Format(@"product={0}", selectedItem))
                                                   : line);
          
            else
                inilines = inilines.Select(line => (line == string.Format("#product={0}", selectedItem) || line == string.Format(@"product={0}", selectedItem)) 
                                                   ? line.Replace(line, string.Format(@".*product={0}", selectedItem), string.Format(@"#product={0}", selectedItem)) 
                                                   : line);
            
            if (chklbproduct.CheckedItems.Count == 0)
                inilines = inilines.Select(line => Regex.Replace(line, @".*product=all", @"product=all"));
            else
                inilines = inilines.Select(line => Regex.Replace(line, @".*product=all", @"#product=all"));
            string strWrite = string.Join(Environment.NewLine, inilines.ToArray());
            File.WriteAllText(installerfilename, strWrite);
        }
