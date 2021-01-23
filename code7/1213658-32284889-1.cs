    dtData.Rows.Count.Dump("rows");
    
    var perno = rnd.Next(1000).ToString();
    
    var sw = new Stopwatch();
    sw.Start();
    DataRow[] dr = dtData.Select("i_pernr=" + perno + "");
    dr.CopyToDataTable(dtTemp,LoadOption.OverwriteChanges);
    sw.Stop();
    sw.ElapsedMilliseconds.Dump("elapsed");
    sw.ElapsedTicks.Dump("ticks");
