        private void destination()
        {
            if (rbUK.Checked)
            {
                string[] lines = File.ReadAllLines(@".\Debug\PostageCosts.csv");
                if(lines.Length > 0)
                {
                    var values = lines[0].Split(',');
                    for(int x = 0; x < 6; x++)
                        UK.Add(decimal.Parse(values[x]));
                }
                if(lines.Length > 1)
                {
                    var values = lines[1].Split(',');
                    for(int x = 0; x < 6; x++)
                        RestOfEurop.Add(decimal.Parse(values[x]));
                }
                if(lines.Length > 2)
                {
                    var values = lines[2].Split(',');
                    for(int x = 0; x < 6; x++)
                        WorlWide.Add(decimal.Parse(values[x]));
                }
                int listToShow = 0;
                display(listToShow);
            }
        }
        public void display(int listToShow)
        {
            List<decimal> showList = (listToShow == 0 ? UK : 
                                      listToShow == 1 ? RestOfEurope : 
                                                        WorlWide);
            label2.Text = string.Join("-",  showList.ToArray());
        }
