      private static String Nvl(String value, String suffix) {
        return (null == value) ? "" : value + " " + suffix;
      }
    
    ...
    
      ws.Rows[index].Cells[24].Value = i.IliskiliCokluIsler.Count == 0 
        ? String.Concat(
            Nvl(i.IliskiliMahalle.MahalleAdi, "Mahallesi"),
            Nvl(i.IliskiliYerGorme.Sokak, "Sokak"),
            ...
            Nvl(i.IliskiliYerGorme.KatNo, "Kat"),
            i.IliskiliIlce.IlceAdi, 
            i.IliskiliSehir.SehirAdi)
        : ""; 
