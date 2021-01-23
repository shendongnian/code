    List<String[]> results = new List<String[]>();
    String[] rawdata = File.ReadAllLines("c:\\data.txt");
    for (int i = 2; i < rawdata.Length; i++)
    {
        String[] tmp = rawdata[i].Split(',');
        if (tmp.Length == 10)
        {
            if ((tmp[0] == "Master") && (i < rawdata.Length))
            {
                float col4;
                float col5;
                float col6;
                float col7;
                float col8;
                float col9;
                float col10;
                float sum;
                String[] tmp2 = rawdata[i + 1].Split(',');
                if (tmp2.Length == 10 && tmp2[0] == "Detail" && tmp[1] == tmp2[1] )                           
                {
                    if (float.TryParse(tmp2[3], out col4) && float.TryParse(tmp2[4], out col5) && float.TryParse(tmp2[5], out col6) && float.TryParse(tmp2[6], out col7) && float.TryParse(tmp2[7], out col8) && float.TryParse(tmp2[8], out col9) && float.TryParse(tmp2[9], out col10))
                    {
                        if (float.TryParse(tmp[7], out sum))
                        {
                            if (sum == col4 + col5 + col6 + col7 + col8 + col9 + col10)
                            {
                                results.Add(new String[] { tmp[1], "Matches" });
                            }
                            else results.Add(new String[] { tmp[1], "Doesnt match" });
                            continue;
                        }
                    }          
                }
                results.Add(new String[] { tmp[1], "No detail" });
            }
        }
    }
