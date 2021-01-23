    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb ht = new HtmlWeb();
            //XDocument Mydocument = Data.createData();
            //MessageBox.Show(Mydocument.ToString());
            //Data.SaveData("myfirst.xml");
            try
            {
                doc = ht.Load("http://www.curs.md/curs_valutar_banci");
            }
            catch 
            { 
                MessageBox.Show("Eroare la conectare cu sursa...");
                Close();
            }
            string[] result = new string[50];
            string[] banci = new string[] { "bnm", "eneg", "ecb", "exim", "fin", "mobi", "micb", "maib", "proc", "vb" };
            string[,] banciforxml=new string[10,15];
            for (int i = 0; i < banci.Length; i++)
            {
                try
                {
                    HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table/tbody/tr[@class='" + banci[i] + "']/td");
                    for (int x = 0; x < 15; x++)
                    {
                        result[x] = nodes[x].InnerText;
                        banciforxml[i,x]=result[x];
                        listBox1.Items.Add("Result "+i+":"+x+" -> "+banciforxml[i,x]);
                    }
                }
                catch
                {
                    string value = banci[i];
                    switch (value)
                    {
                        case "bnm":
                            MessageBox.Show("Banca Nationala nu functioneaza!!");
                            continue;
                        case "eneg":
                            MessageBox.Show("Energbank nu functioneaza!!");
                            continue;
                        case "ecb":
                            MessageBox.Show("EuroCreditBank nu functioneaza!!");
                            continue;
                        case "exim":
                            MessageBox.Show("Eximbank nu functioneaza!!");
                            continue;
                        case "fin":
                            MessageBox.Show("FinComBank nu functioneaza!!");
                            continue;
                        case "mobi":
                            MessageBox.Show("Mobiasbanca nu functioneaza!!");
                            continue;
                        case "micb":
                            MessageBox.Show("Moldindconbank nu functioneaza!!");
                            continue;
                        case "maib":
                            MessageBox.Show("Moldova Agroindbank nu functioneaza!!");
                            continue;
                        case "proc":
                            MessageBox.Show("ProCredit Bank nu functioneaza!!");
                            continue;
                        case "vb":
                            MessageBox.Show("Victoriabank nu functioneaza!!");
                            continue;
                    }
                        
                }
                
            }
            XDocument myDocument=Data.createData(banciforxml);//<-Here is the problem
            listBox1.Items.Add(myDocument);
