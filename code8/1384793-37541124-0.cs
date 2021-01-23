    List<string[]> fileContents = new List<string[]>();
                var lines = File.ReadAllLines(ofd.FileName).ToList();
                foreach (var item in lines)
                {
                    string RegNo = string.Format("{0}", item.ToString().Substring(0, 19));
                    string accHolder = string.Format("{0}", item.ToString().Substring(21, 30));
                    string amount = string.Format("{0}", item.ToString().Substring(52, 11));
                    string accNo = string.Format("{0}", item.ToString().Substring(64, 13));
                    string branch = string.Format("{0}", item.ToString().Substring(78, 6));
                    string date = string.Format("{0}-{1}-{2}", "20" + item.ToString().Substring(85, 2), item.ToString().Substring(87, 2), item.ToString().Substring(89, 2));
                    string code = string.Format("{0}", item.ToString().Substring(92, 2));
                    string orphenColumn = string.Format("{0}", item.ToString().Substring(95, 1));
                    lstRegNo.Add(RegNo.Trim());
                    lstAccHolder.Add(ExtensionMethods.RemoveSpecialCharacters(accHolder.Trim()));
                    lstAmount.Add(amount.Trim());
                    lstAccNo.Add(accNo.Trim());
                    lstBranch.Add(branch.Trim());
                    lstDate.Add(date);
                    lstCode.Add(code.Trim());
                    lstOrphenColumn.Add(orphenColumn);
                }
