      private static string NvlSuffix(string value, string suffix) {
        return (null == value) ? "" : value + " " + suffix;
      }
      private static string NvlPrefix(string value, string prefix) {
        return (null == value) ? "" : prefix + " " + value;
      }
    
    ...
    
      ws.Rows[index].Cells[24].Value = i.IliskiliCokluIsler.Count == 0 
        ? string.Concat(
            NvlSuffix(i.IliskiliMahalle.MahalleAdi, "Mahallesi"),
            NvlSuffix(i.IliskiliYerGorme.Sokak, "Sokak"),
            NvlPrefix(i.IliskiliYerGorme.BinaNo, "Bina no"), 
            NvlSuffix(i.IliskiliYerGorme.KatNo, "Kat"),
            i.IliskiliIlce.IlceAdi, 
            i.IliskiliSehir.SehirAdi)
        : ""; 
