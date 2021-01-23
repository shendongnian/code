    string data = "ADD GCELL:CELLID=13, CELLNAME=\"NR_0702_07021_G1_A\", MCC=\"424\", MNC=\"02\", LAC=6112, CI=7021, NCC=6, BCC=0, EXTTP=Normal_cell, IUOTP=Concentric_cell, ENIUO=ON, DBFREQBCCHIUO=Extra, FLEXMAIO=OFF, CSVSP=3, CSDSP=5, PSHPSP=4, PSLPSVP=6, BSPBCCHBLKS=1, BSPAGBLKSRES=4, BSPRACHBLKS=1, TYPE=GSM900_DCS1800, OPNAME=\"Tester\", VIPCELL=NO" + Environment.NewLine;
    data = data + "ADD GTRX:TRXID=11140, TRXNAME=\"T_RAK_JaziratHamra_G_702_7021_A-0\", FREQ=99, TRXNO=0, CELLID=13, IDTYPE=BYID, ISMAINBCCH=YES, ISTMPTRX=NO, GTRXGROUPID=80;" + Environment.NewLine;
    using (var sr = new StringReader(data))
    {
        string line = sr.ReadLine();
        while (line != null)
        {
            line = line.Trim();
            if (line.StartsWith("ADD GCELL:"))
            {
                var gcell = new Gcell
                {
                    CellId = int.Parse(PullValue(line, "CELLID")),
                    CellName = PullValue(line, "CELLNAME"),
                    Ci = int.Parse(PullValue(line, "CI")),
                    Lac = int.Parse(PullValue(line, "LAC")),
                    Mcc = PullValue(line, "MCC")
                };
                var gcellGtrx = new GcellGtrx();
                gcellGtrx.Gcell = gcell;
                _dictionary.Add(gcell.CellId, gcellGtrx);
            }
            if (line.StartsWith("ADD GTRX:"))
            {
                var gtrx = new Gtrx
                {
                    CellId = int.Parse(PullValue(line, "CELLID")),
                    Freq = int.Parse(PullValue(line, "FREQ")),
                    TrxNo = int.Parse(PullValue(line, "TRXNO")),
                    IsMainBcch = PullValue(line, "ISMAINBCCH").ToUpper() == "YES",
                    TrxName = PullValue(line, "TRXNAME")
                };
                if (!_dictionary.ContainsKey(gtrx.CellId))
                {
                    // No GCell record for this id. Do something!
                    continue;
                }
                _dictionary[gtrx.CellId].Gtrx = gtrx;
            }
            line = sr.ReadLine();
        }
    }
    // Now you can pull your data using a CellId:
    // GcellGtrx cell13 = _dictionary[13];
    // 
    // Or you could iterate through each one:
    // foreach (KeyValuePair<int, GcellGtrx> kvp in _dictionary)
    // {
    //     int key = kvp.Key;
    //     GcellGtrx gCellGtrxdata = kvp.Value;
    //     // Do Stuff
    // }
